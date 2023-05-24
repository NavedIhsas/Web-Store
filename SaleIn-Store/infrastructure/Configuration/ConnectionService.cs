using Azure.Core;
using Domain.SaleInModels;
using infrastructure.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace infrastructure.Configuration
{
    public class ConnectionService
    {
        public static void Configure(IServiceCollection services, IServiceProvider provider, IConfiguration configuration)
        {
           var context= provider.GetService<IHttpContextAccessor>();
           
            var t=  context.HttpContext.Session.GetJson<string>("Branch");
          var connectionString=  configuration.GetConnectionString("saleInConnection");
            services.AddDbContext<SaleInContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
