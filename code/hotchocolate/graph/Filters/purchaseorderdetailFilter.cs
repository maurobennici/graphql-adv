using HotChocolate.Data.Filters;
using repository.Models;

namespace graph.Filters
{
    public class purchaseorderdetailFilter : FilterInputType<purchaseorderdetail>
    {
        protected override void Configure(IFilterInputTypeDescriptor<purchaseorderdetail> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(x => x.duedate);
            descriptor.Field(x => x.unitprice);
            descriptor.Field(x => x.orderqty);

            descriptor.AllowOr(false);
            descriptor.Ignore(x => x.purchaseorderid);
        }
    }
}