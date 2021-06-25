using AutoMapper;
using Mvp24Hours.Core.Contract.Mappings;
using SimpleAPI.Core.Entity;

namespace SimpleAPI.Core.ValueObjects.Products
{
    public class CreateProductResponse : IMapFrom<Product>
    {
        public virtual int Id { get; set; }

        public virtual void Mapping(Profile profile)
        {
            profile.CreateMap<ProductCategory, CreateProductResponse>();
        }
    }
}
