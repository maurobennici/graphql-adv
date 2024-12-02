using HotChocolate.Execution.Configuration;

namespace graph.Extensions
{
    public partial class RegisterAggregationTypes
    {
        public static void Register(IRequestExecutorBuilder graph)
        {
            graph
                .AddTypeExtension<addressAggregateConnection>()
                .AddTypeExtension<purchaseorderdetailAggregateConnection>()
                .AddTypeExtension<purchaseorderheaderAggregateConnection>()

            //.AddTypeExtension<type>()
            ;
        }
    }
}
