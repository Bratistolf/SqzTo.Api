using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SqzTo.Application.Common.Interfaces;
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
                        builder => builder.MigrationsAssembly(typeof(SqzToDbContext).Assembly.FullName)));
            }

            services.AddScoped<ISqzToDbContext>(provider => provider.GetService<SqzToDbContext>());

           /* services.AddIdentityCore<SqzToUser>()
                .AddEntityFrameworkStores<SqzToDbContext>()
                .AddUserManager<SqzToUser>()
                .AddRoleManager<SqzToUser>()
                .AddSignInManager<SqzToUser>();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 6;
            }
            );

            services.AddAuthorization(options =>
                options.AddPolicy("EmployerPolicy",
                policy => policy.RequireRole("Employer")));

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options => {
                options.RequireHttpsMetadata = true;
                options.SaveToken = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Secret"].ToString())),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };
            });

    */

            return services;
        }
    }
}
