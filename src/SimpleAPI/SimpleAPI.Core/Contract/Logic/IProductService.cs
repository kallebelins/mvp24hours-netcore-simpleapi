using Mvp24Hours.Core.Contract.ValueObjects.Logic;
using Mvp24Hours.Core.DTOs;
using SimpleAPI.Core.ValueObjects.Products;
using System.Threading.Tasks;

namespace SimpleAPI.Core.Contract.Logic
{
    public interface IProductService
    {
        Task<IPagingResult<GetByProductResponse>> GetBy(GetByProductRequest filter, IPagingCriteria criteria);
        Task<IBusinessResult<GetByIdProductResponse>> GetById(int id);
        Task<IBusinessResult<CreateProductResponse>> Create(CreateProductRequest dto);
        Task<IBusinessResult<VoidResult>> Update(int id, UpdateProductRequest dto);
        Task<IBusinessResult<VoidResult>> Delete(int id);
    }
}
