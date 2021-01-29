using Mvp24Hours.Core.Contract.Logic;
using SimpleAPI.Core.Entity.LogFeatures;

namespace SimpleAPI.Core.Contract.Logic.LogFeatures
{
    public interface IProductWithLogService : IQueryService<ProductWithLog>, ICommandService<ProductWithLog>
    {
    }
}
