using Mvp24Hours.Business.Logic;
using Mvp24Hours.Core.Contract.Data;
using SimpleAPI.Core.Contract.Logic.SimpleFeatures;
using SimpleAPI.Core.Entity.SimpleFeatures;

namespace SimpleAPI.Application.Logic.SimpleFeatures
{
    public partial class ProductCategorySimpleService : RepositoryService<ProductCategorySimple, IUnitOfWork>, IProductCategorySimpleService
    {

    }
}
