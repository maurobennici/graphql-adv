using graph.Filters;
using HotChocolate.Resolvers;
using HotChocolate.Types.Pagination;
using Microsoft.EntityFrameworkCore;
using repository.Models;

namespace graph.QueryTypes
{
    public partial class Query : QueryBase
    {
        [UsePaging]
        [UseProjection]
        [UseFiltering<addressFilter>]
        [UseSorting]
        public IQueryable<address> address(IResolverContext context, AdventureworksContext dbContext, [Service] IHttpContextAccessor httpContextAccessor)
        {
            var result = dbContext.addresses.AsNoTracking();
            return result;
        }

        [UsePaging(ConnectionName = "addressAggregate")]
        [UseProjection]
        [UseFiltering<addressFilter>]
        public Connection<address> addressAggregates(IResolverContext context, AdventureworksContext dbContext, [Service] IHttpContextAccessor httpContextAccessor)
        {
            var result = dbContext.addresses.AsNoTracking();

            var connection = AggregateData<address>(context, dbContext, result);

            return connection;
        }
    }
}