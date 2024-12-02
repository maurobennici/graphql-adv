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
        [UseFiltering<purchaseorderdetailFilter>]
        [UseSorting]
        public IQueryable<purchaseorderdetail> purchaseorderdetail(IResolverContext context, AdventureworksContext dbContext, [Service] IHttpContextAccessor httpContextAccessor)
        {
            var result = dbContext.purchaseorderdetails.AsNoTracking();
            return result;
        }

        [UsePaging(ConnectionName = "purchaseorderdetailAggregate")]
        [UseProjection]
        [UseFiltering<purchaseorderdetailFilter>]
        public Connection<purchaseorderdetail> purchaseorderdetailAggregates(IResolverContext context, AdventureworksContext dbContext, [Service] IHttpContextAccessor httpContextAccessor)
        {
            var result = dbContext.purchaseorderdetails.AsNoTracking();

            var connection = AggregateData<purchaseorderdetail>(context, dbContext, result);

            return connection;
        }
    }
}