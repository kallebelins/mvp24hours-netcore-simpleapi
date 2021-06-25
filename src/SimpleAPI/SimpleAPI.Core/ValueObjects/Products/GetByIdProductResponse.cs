using AutoMapper;
using Mvp24Hours.Core.Contract.Mappings;
using SimpleAPI.Core.Entity;

namespace SimpleAPI.Core.ValueObjects.Products
{
    public class GetByIdProductResponse : GetByProductResponse, IMapFrom<Product>
    {
        public virtual string Description { get; set; }

        public override void Mapping(Profile profile)
        {
            profile.CreateMap<Product, GetByIdProductResponse>();
        }
    }
}
