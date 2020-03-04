using System.Net;
using AutoMapper;
using com.b_velop.Stack.Air.Contracts;
using com.b_velop.Stack.Air.Data;
using com.b_velop.Stack.Air.Data.Repositories;
using com.b_velop.Utilities.Docker;
using com.b_velop.Utilities.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Stack.Air
{
    public class Startup
    {
        public Startup(
            IConfiguration configuration,
            IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.DateFormatString = "yyyy-MM-ddTHH:mm:ss";
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            services.AddAutoMapper(typeof(Program).Assembly);
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            services.AddScoped<IValueRepository, ValueRepository>();
            services.AddScoped<ITimeRepository, TimeRepository>();
            services.AddScoped<ISensorRepository, SensorRepository>();
            //if (Environment.IsDevelopment())
            //{
            //    services.AddDbContext<DataContext>(options =>
            //    {
            //        options.UseSqlite(Configuration.GetConnectionString("Default"));
            //    });
            //}
            //else
            //{

            var secretProvider = new SecretProvider();
            var password = secretProvider.GetSecret("sqlserver");
            var conString = secretProvider.GetSecret("CON_STRING");
            if (Environment.IsDevelopment())
            {
                password = "str0ngpasswort!";
                conString = "Server=localhost,1433;Database=Air;User Id=sa;Password=";
            }

            services.AddDbContext<IDataContext, DataContext>(options =>
        {
            options.UseSqlServer($"{conString}{password}");
        });
            //}
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env,
            ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseExceptionHandler(builder =>
                {
                    builder.Run(async context =>
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        var error = context.Features.Get<IExceptionHandlerFeature>();
                        if (error != null)
                        {
                            logger.LogError(error.Error, $"Error occurred");
                            context.Response.AddApplicationError(error.Error.Message);
                            await context.Response.WriteAsync(error.Error.Message);
                        }
                    });
                });
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllers();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
                }
            });
        }
    }
}
