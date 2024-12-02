using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data.Common;

namespace graph.Interceptors
{
    public class EFConnectionOpenInterceptor : DbConnectionInterceptor
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public EFConnectionOpenInterceptor(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public override Task ConnectionOpenedAsync(DbConnection connection, ConnectionEndEventData eventData, CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }

        public override void ConnectionOpened(DbConnection connection, ConnectionEndEventData eventData)
        {
            Console.WriteLine("open: " + DateTime.Now.Ticks);
        }

        public override void ConnectionClosed(DbConnection connection, ConnectionEndEventData eventData)
        {
            base.ConnectionClosed(connection, eventData);
            Console.WriteLine("close: " + DateTime.Now.Ticks);
        }
    }
}
