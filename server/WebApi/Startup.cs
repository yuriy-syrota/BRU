using System;
using System.Net;
using Data.Entities;
using Data.Repositories;
using Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NLog.Extensions.Logging;

namespace WebApi
{
    public class Startup
    {
        const string CorsPolicyDev = "AllowAllOrigins";
        const string CorsPolicyProd = "RestrictToHostName";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddNewtonsoftJson(options => {
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                    options.SerializerSettings.DateFormatHandling = DateFormatHandling.MicrosoftDateFormat;
                    options.UseCamelCasing(false);
                });

            services.AddDbContext<BRUContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("BRU_DbConnectionString")).EnableSensitiveDataLogging());

            services.AddLogging(builder =>
            {
                builder.AddConfiguration(Configuration.GetSection("Logging"))
                    .AddConsole()
                    .AddDebug()
                    .AddNLog();
            });

            services.AddSingleton(typeof(ILogger), typeof(Logger<string>));
            services.AddScoped<IMainRepository, MainRepository>();
            services.AddScoped<IReferenceRepository, ReferenceRepository>();
            
            services.AddCors(options =>
                options.AddPolicy(CorsPolicyDev,
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    }));

            services.AddCors(options =>
                options.AddPolicy(CorsPolicyProd,
                    builder =>
                    {
                        builder.WithOrigins(Configuration["AllowedHosts"].Split(';', StringSplitOptions.RemoveEmptyEntries));
                    }));

            services.AddAutoMapper(typeof(Startup));

            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.KnownProxies.Add(IPAddress.Parse(Configuration["Proxy:IP"]));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //app.UseHostFiltering();

            if (env.EnvironmentName == "Development")
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection(); // this breaks things in UAT
            app.UseStaticFiles();
            app.UseRouting();

            if (env.EnvironmentName == "Development")
            {
                app.UseCors(CorsPolicyDev);
            }
            else
            {
                app.UseCors(CorsPolicyProd);
                app.UseHsts();
            }

            // app.UseResponseCaching();

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            app.UseAuthentication();

            app.UseAuthorization();
            app.UseEndpoints(endpoints => {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}

