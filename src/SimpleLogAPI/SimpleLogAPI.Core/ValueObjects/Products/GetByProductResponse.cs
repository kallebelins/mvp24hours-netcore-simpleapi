using AutoMapper;
using Mvp24Hours.Core.Contract.Mappings;
using SimpleLogAPI.Core.Entity;
using System.Collections.Generic;

namespace SimpleLogAPI.Core.ValueObjects.Products
{
    public class GetByProductResponse : IMapFrom<Product>
    {
        public virtual int Id { get; set; }
        public int ProductCategoryId { get; set; }
        public virtual string Name { get; set; }
        public decimal? UnitPrice { get; set; }

        public virtual void Mapping(Profile profile)
        {
            profile.CreateMap<Product, GetByProductResponse>();
            profile.CreateMap<List<Product>, List<GetByProductResponse>>();
        }
    }
}
