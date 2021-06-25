using AutoMapper;
using Mvp24Hours.Core.Contract.Mappings;
using SimpleAPI.Core.Entity;

namespace SimpleAPI.Core.ValueObjects.ProductCategories
{
    public class GetByIdProductCategoryResponse : GetByProductCategoryResponse, IMapFrom<ProductCategory>
    {
        public override void Mapping(Profile profile)
        {
            profile.CreateMap<ProductCategory, GetByIdProductCategoryResponse>();
        }
    }
}
