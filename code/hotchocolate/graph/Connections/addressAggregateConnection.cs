using graph.Enums;
using repository.Models;

namespace graph.Extensions
{
    [ExtendObjectType("addressAggregateConnection")]
    public class addressAggregateConnection : AggregateConnection<address, addressAggregateEnum> { }
}