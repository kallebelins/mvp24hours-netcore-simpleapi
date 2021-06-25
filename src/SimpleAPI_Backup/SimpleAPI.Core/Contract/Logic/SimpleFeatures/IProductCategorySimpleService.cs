using Mvp24Hours.Core.Contract.Logic;
using SimpleAPI.Core.Entity.SimpleFeatures;

namespace SimpleAPI.Core.Contract.Logic.SimpleFeatures
{
    public interface IProductCategorySimpleService : IQueryService<ProductCategorySimple>, ICommandService<ProductCategorySimple>
    {
    }
}
