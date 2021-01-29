using Mvp24Hours.Infrastructure.Helpers;
using SimpleAPI.Core.Contract.Logic.GuidFeatures;
using SimpleAPI.Core.Contract.Logic.LogFeatures;
using SimpleAPI.Core.Contract.Logic.PagingFeatures;
using SimpleAPI.Core.Contract.Logic.SimpleFeatures;

namespace SimpleAPI.Application
{
    /// <summary>
    /// 
    /// </summary>
    public class FacadeService
    {

        #region [ Simple Services ]
        public static IProductSimpleService ProductSimpleService
        {
            get { return HttpContextHelper.GetService<IProductSimpleService>(); }
        }
        public static IProductCategorySimpleService ProductCategorySimpleService
        {
            get { return HttpContextHelper.GetService<IProductCategorySimpleService>(); }
        }
        #endregion

        #region [ Paging Services ]
        public static IProductWithPagingService ProductWithPagingService
        {
            get { return HttpContextHelper.GetService<IProductWithPagingService>(); }
        }
        public static IProductCategoryWithPagingService ProductCategoryWithPagingService
        {
            get { return HttpContextHelper.GetService<IProductCategoryWithPagingService>(); }
        }
        #endregion

        #region [ Guid Services ]
        public static IProductWithGuidService ProductWithGuidService
        {
            get { return HttpContextHelper.GetService<IProductWithGuidService>(); }
        }
        public static IProductCategoryWithGuidService ProductCategoryWithGuidService
        {
            get { return HttpContextHelper.GetService<IProductCategoryWithGuidService>(); }
        }
        #endregion

        #region [ Log Services ]
        public static IProductWithLogService ProductWithLogService
        {
            get { return HttpContextHelper.GetService<IProductWithLogService>(); }
        }
        public static IProductCategoryWithLogService ProductCategoryWithLogService
        {
            get { return HttpContextHelper.GetService<IProductCategoryWithLogService>(); }
        }
        #endregion
    }
}
