using Mvp24Hours.Business.Logic;
using Mvp24Hours.Core.Contract.Data;
using SimpleAPI.Core.Contract.Logic.GuidFeatures;
using SimpleAPI.Core.Entity.GuidFeatures;

namespace SimpleAPI.Application.Logic.GuidFeatures
{
    public partial class ProductWithGuidService : RepositoryService<ProductWithGuid, IUnitOfWork>, IProductWithGuidService
    {

    }
}
