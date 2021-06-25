using Mvp24Hours.Business.Logic;
using Mvp24Hours.Core.Contract.Data;
using SimpleAPI.Core.Contract.Logic.PagingFeatures;
using SimpleAPI.Core.Entity.SimpleFeatures;

namespace SimpleAPI.Application.Logic.PagingFeatures
{
    public partial class ProductCategoryWithPagingService : RepositoryPagingService<ProductCategorySimple, IUnitOfWork>, IProductCategoryWithPagingService
    {
    }
}
