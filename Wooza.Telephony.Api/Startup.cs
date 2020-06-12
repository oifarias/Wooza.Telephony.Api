using App.Metrics;
using App.Metrics.Extensions.Configuration;
using App.Metrics.Formatters.Prometheus;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Linq;
using System.Reflection;
using Wooza.Telephony.Repository.Data;

namespace Wooza.Telephony.Api
{
    public class Startup
    {
        public IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddControllers()
                .AddControllersAsServices()
                .AddMetrics();
            services
                .AddDbContext<DataContext>
                (opt => opt.UseInMemoryDatabase("DataBasePlan"));
            services.AddScoped<DataContext, DataContext>();
            
            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            services.AddCors();

            services.AddHealthChecks();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Wooza Telephony Api", Version = "v1" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = System.IO.Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });


            var metrics = AppMetrics.CreateDefaultBuilder()
                .Configuration.ReadFrom(Configuration)
                .OutputMetrics.AsPrometheusPlainText()
                .Build();

            services.AddMetrics(metrics);
            services.AddMetricsEndpoints(endpointsOptions => endpointsOptions.MetricsEndpointOutputFormatter = endpointsOptions.MetricsOutputFormatters.OfType<MetricsPrometheusTextOutputFormatter>().First());
            services.AddMetricsReportingHostedService();
            services.AddMetricsTrackingMiddleware(Configuration);

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseRouting();

            app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

            app.UseMetricsEndpoint();
            app.UseMetricsAllMiddleware();

            app.UseSwagger(c =>
            {
                c.RouteTemplate = "/internal/swagger/{documentName}/swagger.json";
            });
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "internal/swagger";
                c.SwaggerEndpoint("/internal/swagger/v1/swagger.json", "Wooza Telephony");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/internal/healthcheck");
            });
        }
    }
}