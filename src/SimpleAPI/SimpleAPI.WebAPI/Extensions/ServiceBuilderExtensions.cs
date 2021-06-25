using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mvp24Hours.Core.Contract.Domain.Validations;
using Mvp24Hours.Infrastructure.Validations;
using SimpleAPI.Application.Logic;
using SimpleAPI.Core.Contract.Logic;
using SimpleAPI.Core.Entity;
using SimpleAPI.Infrastructure.Data;

namespace SimpleAPI.WebAPI.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class ServiceBuilderExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        public static IServiceCollection AddMyDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SimpleAPIContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("SimpleAPIContext")));

            return services;
        }

        /// <summary>
        /// 
        /// </summary>
        public static IServiceCollection AddMyServices(this IServiceCollection services)
        {
            // services
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductCategoryService, ProductCategoryService>();

            return services;
        }

        /// <summary>
        /// 
        /// </summary>
        public static IServiceCollection AddPolicies(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    });
            });

            return services;
        }
    }
}
