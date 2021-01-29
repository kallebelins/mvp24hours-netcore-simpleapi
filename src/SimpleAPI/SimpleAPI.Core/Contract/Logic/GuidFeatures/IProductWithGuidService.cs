using Mvp24Hours.Core.Contract.Logic;
using SimpleAPI.Core.Entity.GuidFeatures;

namespace SimpleAPI.Core.Contract.Logic.GuidFeatures
{
    public interface IProductWithGuidService : IQueryService<ProductWithGuid>, ICommandService<ProductWithGuid>
    {
    }
}
