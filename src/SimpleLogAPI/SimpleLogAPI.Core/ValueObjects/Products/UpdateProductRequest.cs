using AutoMapper;
using Mvp24Hours.Core.Contract.Mappings;
using SimpleLogAPI.Core.Entity;

namespace SimpleLogAPI.Core.ValueObjects.Products
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
