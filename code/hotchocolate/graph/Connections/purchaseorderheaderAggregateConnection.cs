using graph.Enums;
using repository.Models;

namespace graph.Extensions
{
    [ExtendObjectType("purchaseorderheaderAggregateConnection")]
    public class purchaseorderheaderAggregateConnection : AggregateConnection<purchaseorderheader, purchaseorderheaderAggregateEnum> { }
}