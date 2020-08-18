using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SqzTo.Application.Common.Behaviours;
using SqzTo.Application.Common.Interfaces;
using SqzTo.Application.Common.Mappings;
using SqzTo.Application.Common.Services.UrlShorteners;
using System.Reflection;

namespace SqzTo.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            #region Mapper DI
            var mappingConfig = new AutoMapperConfig().Configure();
            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            #endregion

            #region Validation DI
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            #endregion

            #region Mediator DI
            services.AddMediatR(Assembly.GetExecutingAssembly());
            #endregion

            #region Services DI
            services.AddScoped<IUrlShorteningService, MD5UrlShorteningService>();
            #endregion

            #region Pipeline Behaviours DI
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            #endregion

            return services;
        }
    }
}
