using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SqzTo.Application.Common.Behaviours;
using SqzTo.Application.Common.Interfaces;
using SqzTo.Application.Common.Services.UrlShorteners;
using System.Reflection;

namespace SqzTo.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<IUrlShorteningService, MD5UrlShorteningService>();
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            return services;
        }
    }
}
