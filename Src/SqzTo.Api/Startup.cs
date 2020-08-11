using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SqzTo.Api.Filters;
using SqzTo.Application;
using SqzTo.Infrastructure;

namespace SqzTo.Api
{
    /// <summary>
    /// Class that configures services and the app's request pipeline.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">An API configuration settings.</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(opt => opt.Filters.Add(new ApiExceptionFilter()));

            ///<summary>
            /// Swagger configurations
            ///</summary>
            services.AddApiVersioning(opt => 
            {
                opt.DefaultApiVersion = new ApiVersion(1, 0);
                opt.AssumeDefaultVersionWhenUnspecified = true;
                opt.ReportApiVersions = true;
            });
            services.AddOpenApiDocument();


            services.AddCors(opt => opt.AddPolicy("DevCORSPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddApplication();
            services.AddInfrastructure(Configuration);
        }

        /// <summary>
        /// Used to specify how the app responds to HTTP requests. The request pipeline is configured by adding middleware components to an <see cref="IApplicationBuilder"/> instance.
        /// </summary>
        /// <param name="app">Application request pipeline builder.</param>
        /// <param name="env">Web host environment provider.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("DevCORSPolicy");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseOpenApi();
            app.UseSwaggerUi3();
            //app.UseReDoc();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
