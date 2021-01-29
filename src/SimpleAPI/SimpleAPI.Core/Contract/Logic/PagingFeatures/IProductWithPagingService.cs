using Mvp24Hours.Core.Contract.Logic;
using SimpleAPI.Core.Entity.SimpleFeatures;

namespace SimpleAPI.Core.Contract.Logic.PagingFeatures
{
    public interface IProductWithPagingService : IQueryPagingService<ProductSimple>, IQueryService<ProductSimple>
    {
    }
}
