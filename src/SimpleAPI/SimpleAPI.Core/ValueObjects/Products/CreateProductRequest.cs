using AutoMapper;
using Mvp24Hours.Core.Contract.Mappings;
using SimpleAPI.Core.Entity;

namespace SimpleAPI.Core.ValueObjects.Products
{
    public class CreateProductRequest : IMapFrom<Product>
    {
        public int ProductCategoryId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public decimal? UnitPrice { get; set; }

        public virtual void Mapping(Profile profile)
        {
            profile.CreateMap<CreateProductRequest, Product>();
        }
    }
}
