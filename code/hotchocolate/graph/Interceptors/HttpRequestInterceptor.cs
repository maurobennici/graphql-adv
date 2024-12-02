using HotChocolate.AspNetCore;
using HotChocolate.Execution;

namespace graph.Interceptors
{
    public class HttpRequestInterceptor : DefaultHttpRequestInterceptor
    {
        public override ValueTask OnCreateAsync(HttpContext context,
            IRequestExecutor requestExecutor, OperationRequestBuilder requestBuilder,
            CancellationToken cancellationToken)
        {
            // example
            //requestBuilder.SetProperty("name", new User { Name = "Joe" });

            // Row Level Security
            // requestBuilder.SetGlobalState("domainid", 23);

            return base.OnCreateAsync(context, requestExecutor, requestBuilder, cancellationToken);
        }
    }
}
