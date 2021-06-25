using Mvp24Hours.Infrastructure.Helpers;
using SimpleAPI.Core.Contract.Logic.GuidFeatures;
using SimpleAPI.Core.Contract.Logic.LogFeatures;
using SimpleAPI.Core.Contract.Logic.PagingFeatures;
using SimpleAPI.Core.Contract.Logic.SimpleFeatures;

namespace SimpleAPI.Application
{
    /// <summary>
    /// Provides all services available for use in this project
    /// </summary>
    public class FacadeService
    {

        #region [ Simple Services ]
        /// <summary>
        /// <see cref="SimpleAPI.Core.Contract.Logic.SimpleFeatures.IProductSimpleService"/>
        /// </summary>
        public static IProductSimpleService ProductSimpleService => ServiceProviderHelper.GetService<IProductSimpleService>();
        /// <summary>
        /// <see cref="SimpleAPI.Core.Contract.Logic.SimpleFeatures.IProductCategorySimpleService"/>
        /// </summary>
        public static IProductCategorySimpleService ProductCategorySimpleService => ServiceProviderHelper.GetService<IProductCategorySimpleService>();
        #endregion

        #region [ Paging Services ]
        /// <summary>
        /// <see cref="SimpleAPI.Core.Contract.Logic.PagingFeatures.IProductWithPagingService"/>
        /// </summary>
        public static IProductWithPagingService ProductWithPagingService => ServiceProviderHelper.GetService<IProductWithPagingService>();
        /// <summary>
        /// <see cref="SimpleAPI.Core.Contract.Logic.PagingFeatures.IProductCategoryWithPagingService"/>
        /// </summary>
        public static IProductCategoryWithPagingService ProductCategoryWithPagingService => ServiceProviderHelper.GetService<IProductCategoryWithPagingService>();
        #endregion

        #region [ Guid Services ]
        /// <summary>
        /// <see cref="SimpleAPI.Core.Contract.Logic.GuidFeatures.IProductWithGuidService"/>
        /// </summary>
        public static IProductWithGuidService ProductWithGuidService => ServiceProviderHelper.GetService<IProductWithGuidService>();
        /// <summary>
        /// <see cref="SimpleAPI.Core.Contract.Logic.GuidFeatures.IProductCategoryWithGuidService"/>
        /// </summary>
        public static IProductCategoryWithGuidService ProductCategoryWithGuidService => ServiceProviderHelper.GetService<IProductCategoryWithGuidService>();
        #endregion

        #region [ Log Services ]
        /// <summary>
        /// <see cref="SimpleAPI.Core.Contract.Logic.LogFeatures.IProductWithLogService"/>
        /// </summary>
        public static IProductWithLogService ProductWithLogService => ServiceProviderHelper.GetService<IProductWithLogService>();
        /// <summary>
        /// <see cref="SimpleAPI.Core.Contract.Logic.LogFeatures.IProductCategoryWithLogService"/>
        /// </summary>
        public static IProductCategoryWithLogService ProductCategoryWithLogService => ServiceProviderHelper.GetService<IProductCategoryWithLogService>();
        #endregion
    }
}
