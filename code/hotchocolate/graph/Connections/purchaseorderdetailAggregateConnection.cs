using graph.Enums;
using repository.Models;

namespace graph.Extensions
{
    [ExtendObjectType("purchaseorderdetailAggregateConnection")]
    public class purchaseorderdetailAggregateConnection : AggregateConnection<purchaseorderdetail, purchaseorderdetailAggregateEnum> { }
}