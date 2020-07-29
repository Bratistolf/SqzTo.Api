using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SqzTo.Application.Common.Interfaces;
using SqzTo.Application.Common.Services.UrlShorteners;
using System.Reflection;

namespace SqzTo.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<IUrlShorteningService, MD5UrlShorteningService>();

            return services;
        }
    }
}
