using AutoMapper;
using Mvp24Hours.Core.Contract.Mappings;
using SimpleAPI.Core.Entity;

namespace SimpleAPI.Core.ValueObjects.Products
{
    public class UpdateProductRequest : IMapFrom<Product>
    {
        public virtual string Name { get; set; }

        public virtual void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateProductRequest, Product>();
        }
    }
}
