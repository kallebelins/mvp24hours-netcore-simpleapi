using Mvp24Hours.Core.Contract.Logic;
using Mvp24Hours.Core.Contract.ValueObjects.Logic;
using Mvp24Hours.Core.DTOs;
using SimpleAPI.Core.Entity.GuidFeatures;
using SimpleAPI.Core.ValueObjects.GuidFeatures.ProductCategories;
using System.Threading.Tasks;

namespace SimpleAPI.Core.Contract.Logic.GuidFeatures
{
    public interface IProductCategoryWithGuidService
    {
        Task<IPagingResult<GetByProductCategoryWithGuidResponse>> GetBy(GetByProductCategoryWithGuidRequest filter, IPagingCriteria criteria);
        Task<IBusinessResult<GetByIdProductCategoryWithGuidResponse>> GetById(int id);
        Task<IBusinessResult<CreateProductCategoryWithGuidResponse>> Create(CreateProductCategoryWithGuidRequest dto);
        Task<IBusinessResult<VoidResult>> Update(int id, UpdateProductCategoryWithGuidRequest dto);
        Task<IBusinessResult<VoidResult>> Delete(int id);

    }
}
