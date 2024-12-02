using HotChocolate.Data.Filters;
using repository.Models;

namespace graph.Filters
{
    public class purchaseorderheaderFilter : FilterInputType<purchaseorderheader>
    {
        protected override void Configure(IFilterInputTypeDescriptor<purchaseorderheader> descriptor)
        {
            descriptor.BindFieldsImplicitly();
        }
    }
}