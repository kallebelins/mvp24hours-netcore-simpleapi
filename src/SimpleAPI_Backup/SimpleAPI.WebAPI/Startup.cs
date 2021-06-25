using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Mvp24Hours.Infrastructure.Middlewares;
using Mvp24Hours.WebAPI.Extensions;
using Mvp24Hours.WebAPI.Middlewares;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SimpleAPI.Application.Logic.GuidFeatures;
using SimpleAPI.Application.Logic.LogFeatures;
using SimpleAPI.Application.Logic.PagingFeatures;
using SimpleAPI.Application.Logic.SimpleFeatures;
using SimpleAPI.Core.Contract.Logic.GuidFeatures;
using SimpleAPI.Core.Contract.Logic.LogFeatures;
using SimpleAPI.Core.Contract.Logic.PagingFeatures;
using SimpleAPI.Core.Contract.Logic.SimpleFeatures;
using SimpleAPI.Infrastructure.Data;
using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;

namespace SimpleAPI.WebAPI
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
            #region [ JsonSerializer ]
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.IgnoreNullValues = true;
            });
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                DateFormatHandling = DateFormatHandling.MicrosoftDateFormat,
                DateFormatString = "yyyy-MM-dd"
            };
            #endregion

            #region [ Cache ]
            services.AddMemoryCache();
            #endregion

            #region  [ ResponseCaching ]
            // caching response for middlewares
            services.AddResponseCaching();
            #endregion

            #region [ Database Context ]
            services.AddDbContext<SimpleAPIContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("SimpleAPIContext")));
            #endregion

            #region [ Mvp24Hours ]
            services.AddMvp24HoursService<SimpleAPIContext>();
            #endregion

            #region [ MyServices ]

            #region [ Simple ]
            services.AddScoped<IProductSimpleService>(x => new ProductSimpleService());
            services.AddScoped<IProductCategorySimpleService>(x => new ProductCategorySimpleService());
            #endregion

            #region [ Paging ]
            services.AddScoped<IProductWithPagingService>(x => new ProductWithPagingService());
            services.AddScoped<IProductCategoryWithPagingService>(x => new ProductCategoryWithPagingService());
            #endregion

            #region [ Guid ]
            services.AddScoped<IProductWithGuidService>(x => new ProductWithGuidService());
            services.AddScoped<IProductCategoryWithGuidService>(x => new ProductCategoryWithGuidService());
            #endregion

            #region [ Log ]
            services.AddScoped<IProductWithLogService>(x => new ProductWithLogService());
            services.AddScoped<IProductCategoryWithLogService>(x => new ProductCategoryWithLogService());
            #endregion

            #endregion

            #region [ Swagger ]
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Simple API", Version = "v1" });

                //c.DocumentFilter<CustomSwaggerFilter>();
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
            #endregion

            #region [ Compression ]
            services.Configure<GzipCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.Optimal;
            });
            #endregion

            #region [ Controllers ]
            services.AddControllers();
            services.AddMvc();
            #endregion
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, SimpleAPIContext db)
        {
            // check environment
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                #region [ Custom Exception ]
                app.UseMiddleware<ExceptionMiddleware>();
                #endregion
            }

            #region [ Database Ensure Create ]
            db.Database.EnsureCreated();
            #endregion

            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            #region [ Caching ]
            app.UseMiddleware<CachingMiddleware>();
            //app.UseResponseCaching();
            #endregion

            #region [ Compression ]
            //app.UseResponseCompression();
            #endregion

            #region [ Swagger ]
            app.UseSwagger();
            app.UseSwaggerUI(opt =>
            {
                opt.SwaggerEndpoint("/swagger/v1/swagger.json", "Simple API V1");
            });
            #endregion

            #region [ Mvp24Hours ]
            app.UseMvp24Hours();
            #endregion
        }
    }
}
