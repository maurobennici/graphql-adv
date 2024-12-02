using HotChocolate.Data.Filters;
using repository.Models;

namespace graph.Filters
{
    public class addressFilter: FilterInputType<address>
    {
        protected override void Configure(IFilterInputTypeDescriptor<address> descriptor)
        {
            descriptor.BindFieldsImplicitly();
        }
    }
}