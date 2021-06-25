using Mvp24Hours.Core.Contract.Logic;
using SimpleAPI.Core.Entity.SimpleFeatures;

namespace SimpleAPI.Core.Contract.Logic.SimpleFeatures
{
    public interface IProductSimpleService : IQueryService<ProductSimple>, ICommandService<ProductSimple>
    {
    }
}
