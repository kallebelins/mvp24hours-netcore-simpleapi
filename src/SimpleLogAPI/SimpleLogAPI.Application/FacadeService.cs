using Mvp24Hours.Infrastructure.Helpers;
using SimpleLogAPI.Core.Contract.Logic;

namespace SimpleLogAPI.Application
{
    /// <summary>
    /// Provides all services available for use in this project
    /// </summary>
    public class FacadeService
    {
        /// <summary>
        /// <see cref="Core.Contract.Logic.IProductService"/>
        /// </summary>
        public static IProductService ProductService => ServiceProviderHelper.GetService<IProductService>();
        /// <summary>
        /// <see cref="Core.Contract.Logic.IProductCategoryService"/>
        /// </summary>
        public static IProductCategoryService ProductCategoryService => ServiceProviderHelper.GetService<IProductCategoryService>();
    }
}
