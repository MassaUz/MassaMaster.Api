using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassaMaster.Infrastructure
{
    public static class InfrastructureDependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IRumassaDbContext, RumassaDbContext>(options =>
                options
                    .UseLazyLoadingProxies()
                        .UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}
