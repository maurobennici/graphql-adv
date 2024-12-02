using EntityFrameworkCore.Projectables.Infrastructure;
using graph.Extensions;
using graph.Interceptors;
using graph.Mutations;
using graph.QueryTypes;
using HotChocolate.AspNetCore;
using Microsoft.EntityFrameworkCore;
using repository.Models;

namespace graph
{
    public class Program
    {
        public static void Main(string[] args)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            IWebHostEnvironment? env = builder.Environment;

            var configurationBuilder = new ConfigurationBuilder()
                                .SetBasePath(env.ContentRootPath)
                                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                                .AddEnvironmentVariables();
            IConfigurationRoot configuration = configurationBuilder.Build();

            builder.Services.AddHttpContextAccessor();
            builder.Services.AddTransient<EFConnectionOpenInterceptor>();

            builder.Services.AddDbContext<AdventureworksContext>((serviceProvider, options) =>
            {
                options.UseNpgsql(
                    configuration["ConnectionStrings:DB"],
                    o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SingleQuery)
                );
                options.UseProjectables(options =>
                {
                    options.CompatibilityMode(CompatibilityMode.Limited);
                });
                options.AddInterceptors(serviceProvider.GetRequiredService<EFConnectionOpenInterceptor>());
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            }
            );

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });

            // define
            // https://chillicream.com/docs/hotchocolate/v13/defining-a-schema/queries
            var graph = builder.Services

                // Global Services
                .AddMemoryCache()

                .AddGraphQLServer()
                .AddAuthorization()
                .AddProjections()
                .AddFiltering()
                .ModifyPagingOptions(opt =>
                {
                    opt.MaxPageSize = int.MaxValue;
                    opt.DefaultPageSize = 50;
                })
                .TryAddTypeInterceptor<FilterCollectionTypeInterceptor>()
                .AddMutationType<addressMutation>()
                //.AddConvention<IFilterConvention>(
                //    new FilterConventionExtension(
                //        x => x.AddProviderExtension(
                //        new QueryableFilterProviderExtension(
                //        y => y.AddFieldHandler<QueryableStringInvariantEqualsHandler>()))))
                .AddSorting()
                .AddQueryType<Query>()
                .UseDefaultPipeline()
                //.UseAutomaticPersistedQueryPipeline()
                .AddHttpRequestInterceptor<HttpRequestInterceptor>()
                .ModifyOptions(x => {
                    x.EnableFlagEnums = true;
                    x.SortFieldsByName = true;
                    x.RemoveUnreachableTypes = true;
                    x.RemoveUnusedTypeSystemDirectives = true;
                })
                .AddInMemoryOperationDocumentStorage();
            ;

            RegisterAggregationTypes.Register(graph);
            graph.InitializeOnStartup();

            var app = builder.Build();

            app.UseHttpsRedirection();
            app.UseCors();

            // api
            app.MapGraphQLHttp("/gql").WithOptions(new GraphQLHttpOptions
            {
                EnableGetRequests = true,
                AllowedGetOperations = AllowedGetOperations.Query
            });

            // nitro
            app.MapNitroApp("/graphql").WithOptions(new GraphQLToolOptions
            {
                HttpMethod = DefaultHttpMethod.Get | DefaultHttpMethod.Post,
                ServeMode = GraphQLToolServeMode.Embedded,
                UseBrowserUrlAsGraphQLEndpoint = true,
                GraphQLEndpoint = "/gql",
                Title = "Demo GraphQL",
                //HttpHeaders = new Dictionary<string, string>("")
            });

            app.Run();
        }
    }
}
