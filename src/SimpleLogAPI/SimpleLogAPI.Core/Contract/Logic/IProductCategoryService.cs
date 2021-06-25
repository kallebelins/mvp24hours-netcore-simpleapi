using Mvp24Hours.Core.Contract.ValueObjects.Logic;
using Mvp24Hours.Core.DTOs;
using SimpleLogAPI.Core.ValueObjects.ProductCategories;
using System.Threading.Tasks;

namespace SimpleLogAPI.Core.Contract.Logic
{
    public interface IProductCategoryService
    {
        Task<IPagingResult<GetByProductCategoryResponse>> GetBy(GetByProductCategoryRequest filter, IPagingCriteria criteria);
        Task<IBusinessResult<GetByIdProductCategoryResponse>> GetById(int id);
        Task<IBusinessResult<CreateProductCategoryResponse>> Create(CreateProductCategoryRequest dto);
        Task<IBusinessResult<VoidResult>> Update(int id, UpdateProductCategoryRequest dto);
        Task<IBusinessResult<VoidResult>> Delete(int id);
    }
}
