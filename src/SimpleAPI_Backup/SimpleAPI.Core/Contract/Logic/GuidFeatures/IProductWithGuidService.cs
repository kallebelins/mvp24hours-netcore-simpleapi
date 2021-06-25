using Mvp24Hours.Core.Contract.Logic;
using Mvp24Hours.Core.Contract.ValueObjects.Logic;
using Mvp24Hours.Core.DTOs;
using SimpleAPI.Core.Entity.GuidFeatures;
using SimpleAPI.Core.ValueObjects.GuidFeatures.Products;
using System.Threading.Tasks;

namespace SimpleAPI.Core.Contract.Logic.GuidFeatures
{
    public interface IProductWithGuidService
    {
        Task<IPagingResult<GetByProductWithGuidResponse>> GetBy(GetByProductWithGuidRequest filter, IPagingCriteria criteria);
        Task<IBusinessResult<GetByIdProductWithGuidResponse>> GetById(int id);
        Task<IBusinessResult<CreateProductWithGuidResponse>> Create(CreateProductWithGuidRequest dto);
        Task<IBusinessResult<VoidResult>> Update(int id, UpdateProductWithGuidRequest dto);
        Task<IBusinessResult<VoidResult>> Delete(int id);
    }
}
