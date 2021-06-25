using AutoMapper;
using Mvp24Hours.Core.Contract.Mappings;
using SimpleAPI.Core.Entity;

namespace SimpleAPI.Core.ValueObjects.ProductCategories
{
    public class UpdateProductCategoryRequest : IMapFrom<ProductCategory>
    {
        public virtual string Name { get; set; }

        public virtual void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateProductCategoryRequest, ProductCategory>();
        }
    }
}
