using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SqzTo.Application.Common;
using SqzTo.Infrastructure.Persistence;

namespace SqzTo.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDb"))
            {
                services.AddDbContext<SqzToDbContext>(options =>
                    options.UseInMemoryDatabase("MSConnectionString"));
            }
            else
            {
                services.AddDbContext<SqzToDbContext>(options =>
                    options.UseSqlServer(
                        configuration.GetConnectionString("DefaultConnection"),
                        b => b.MigrationsAssembly(typeof(SqzToDbContext).Assembly.FullName)));
            }

            services.AddScoped<ISqzToDbContext>(provider => provider.GetService<SqzToDbContext>());

            return services;
        }
    }
}
