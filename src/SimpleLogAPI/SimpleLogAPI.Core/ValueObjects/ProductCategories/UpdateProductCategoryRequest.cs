using AutoMapper;
using Mvp24Hours.Core.Contract.Mappings;
using SimpleLogAPI.Core.Entity;

namespace SimpleLogAPI.Core.ValueObjects.ProductCategories
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
