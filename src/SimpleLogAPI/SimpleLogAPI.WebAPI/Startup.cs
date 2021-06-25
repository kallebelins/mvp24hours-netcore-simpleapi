using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Mvp24Hours.WebAPI.Extensions;
using SimpleLogAPI.Infrastructure.Data;
using SimpleLogAPI.WebAPI.Extensions;
using System.Reflection;

namespace SimpleLogAPI.WebAPI
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddResponseCompression();
            services.AddMyDbContext(Configuration);
            services.AddMyServices();
            services.AddPolicies();

            #region [ Mvp24Hours ]
            services.AddMvp24HoursService();
            services.AddMvp24HoursZipService(Configuration);
            services.AddMvp24HoursSwagger("v1", "Simple API", xmlCommentsFileName: "SimpleLogAPI.WebAPI.xml");
            //services.AddMvp24HoursRedisCache(Configuration, "ProCliDbRedis");
            services.AddMvp24HoursDbAsyncService<SimpleLogAPIContext>();
            services.AddMvp24HoursMapService(Assembly.GetExecutingAssembly());
            services.AddMvp24HoursJsonService();
            #endregion

            services.AddControllers();
            services.AddMvc();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, SimpleLogAPIContext db)
        {
            db.Database.EnsureCreated();

            app.UseMvp24HoursCors();
            app.UseMvp24HoursExceptionHandling();

            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors("AllowAll");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/", async (context) =>
                {
                    await context.Response.WriteAsync("Running service...");
                });
            });

            app.UseResponseCompression();

            if (env.IsEnvironment("Prod"))
            {
                app.UseHttpsRedirection();
            }
            else
            {
                app.UseMvp24HoursSwagger("Simple API");
            }

            app.UseMvp24Hours();
        }
    }
}
