using AutoMapper;
using Mvp24Hours.Core.Contract.Mappings;
using SimpleAPI.Core.Entity;

namespace SimpleAPI.Core.ValueObjects.ProductCategories
{
    public class CreateProductCategoryResponse : IMapFrom<ProductCategory>
    {
        public virtual int Id { get; set; }

        public virtual void Mapping(Profile profile)
        {
            profile.CreateMap<ProductCategory, CreateProductCategoryResponse>();
        }
    }
}
