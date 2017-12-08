using ContactBookApi.Models;
using ContactBookApi.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;

namespace ContactBookApi
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile($"appsettings_{env.EnvironmentName}.json", optional: true, reloadOnChange: true);

            this.Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver())
                .AddJsonOptions(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
                .AddMvcOptions(options => { options.CacheProfiles.Add("NoCache", new CacheProfile { NoStore = true, Duration = 0 }); });
            services.AddMemoryCache();

            services.AddDbContext<ContactBookContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ContactBook")));
            services.AddScoped<IContactRepository, ContactRepository>();

            var corsBuilder = new CorsPolicyBuilder();
            corsBuilder.AllowAnyHeader();
            corsBuilder.AllowAnyMethod();
            corsBuilder.AllowAnyOrigin();
            corsBuilder.AllowCredentials();

            services.AddCors(options =>
            {
                options.AddPolicy("SiteCorsPolicy", corsBuilder.Build());
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                loggerFactory.AddConsole(LogLevel.Debug, true);
            }

            loggerFactory.AddLog4Net();

            app.UseCors("SiteCorsPolicy");

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "v1/{controller=Contacts}/{action=Contact}/{id?}");
            });
        }
    }
}
