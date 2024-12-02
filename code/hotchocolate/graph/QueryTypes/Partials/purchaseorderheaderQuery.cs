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
        [UseFiltering<purchaseorderheaderFilter>]
        [UseSorting]
        public IQueryable<purchaseorderheader> purchaseorderheader(IResolverContext context, AdventureworksContext dbContext, [Service] IHttpContextAccessor httpContextAccessor)
        {
            var result = dbContext.purchaseorderheaders.AsNoTracking();
            return result;
        }

        [UsePaging(ConnectionName = "purchaseorderheaderAggregate")]
        [UseProjection]
        [UseFiltering<purchaseorderheaderFilter>]
        public Connection<purchaseorderheader> purchaseorderheaderAggregates(IResolverContext context, AdventureworksContext dbContext, [Service] IHttpContextAccessor httpContextAccessor)
        {
            var result = dbContext.purchaseorderheaders.AsNoTracking();

            var connection = AggregateData<purchaseorderheader>(context, dbContext, result);

            return connection;
        }
    }
}