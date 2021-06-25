using AutoMapper;
using Mvp24Hours.Core.Contract.Mappings;
using SimpleLogAPI.Core.Entity;
using System;

namespace SimpleLogAPI.Core.ValueObjects.Products
{
    public class GetByIdProductResponse : GetByProductResponse, IMapFrom<Product>
    {
        public virtual string Description { get; set; }

        public virtual DateTime Created { get; set; }
        public virtual int? CreatedBy { get; set; }

        public override void Mapping(Profile profile)
        {
            profile.CreateMap<Product, GetByIdProductResponse>();
        }
    }
}
