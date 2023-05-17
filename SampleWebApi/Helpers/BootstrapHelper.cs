
using Microsoft.EntityFrameworkCore;
using Sample.Repositories;
using Sample.Repositories.DbContexts;
using Sample.Services;

namespace SampleWebApi.Helpers
{
    public static class BootstrapHelper
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IEmployeeService, EmployeeService>();

            return services;
        }

        public static IServiceCollection AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EmployeeDbContext>(x => x.UseSqlServer(configuration.GetConnectionString("EmployeeDb")));
            return services;
        }
    }
}
