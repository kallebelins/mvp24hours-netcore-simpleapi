using Mvp24Hours.Business.Logic;
using Mvp24Hours.Core.Contract.Data;
using SimpleAPI.Core.Contract.Logic.LogFeatures;
using SimpleAPI.Core.Entity.LogFeatures;

namespace SimpleAPI.Application.Logic.LogFeatures
{
    public partial class ProductCategoryWithLogService : RepositoryService<ProductCategoryWithLog, IUnitOfWork>, IProductCategoryWithLogService
    {

    }
}
