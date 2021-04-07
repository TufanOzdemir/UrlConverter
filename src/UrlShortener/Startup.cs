using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using UrlShortener.Application;
using UrlShortener.Domain;
using UrlShortener.Domain.Configuration;
using UrlShortener.Domain.Extension;
using UrlShortener.Domain.Logging;
using UrlShortener.Domain.Port;
using UrlShortener.Domain.Service;
using UrlShortener.Domain.UrlModule;
using UrlShortener.Domain.Validation;
using UrlShortener.Infrastructure;
using UrlShortener.Infrastructure.Repository;
using UrlShortener.Middlewares;

namespace UrlShortener
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ApplicationInitializer>());
            services.AddSingleton<ILogService, NLogService>();
            services.AddSingleton<IConfigResolver, ConfigResolver>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddMediatR(typeof(ApplicationInitializer).Assembly);
            services.AddAutoMapper(
                typeof(ApplicationInitializer).Assembly,
                typeof(InfrastructureInitializer).Assembly,
                typeof(Startup).Assembly,
                typeof(DomainInitializer).Assembly);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Url Shortener API", Version = "v1" });
            });

            services.AddScoped<UrlService>();
            services.AddSingleton<IUrlCreator, UrlCreator>();
            services.AddScoped<IUrlRepository, RedisUrlRepository>();
            services.AddCacheManagerService(Configuration);

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "UrlShortener API V1");
            });
            app.UseExceptionMiddleware();
            app.UseStaticFiles();
            app.Use(async (ctx, next) =>
            {
                if (ctx.Request.Path.StartsWithSegments("/"))
                {
                    ctx.Response.Redirect("/swagger/index.html");
                }
                else
                {
                    await next.Invoke();
                }
            });
        }
    }
}
