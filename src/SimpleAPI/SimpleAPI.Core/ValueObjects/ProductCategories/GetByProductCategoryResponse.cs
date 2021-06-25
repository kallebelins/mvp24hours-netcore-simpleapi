using AutoMapper;
using Mvp24Hours.Core.Contract.Mappings;
using SimpleAPI.Core.Entity;
using System.Collections.Generic;

namespace SimpleAPI.Core.ValueObjects.ProductCategories
{
    public class GetByProductCategoryResponse : IMapFrom<ProductCategory>
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }

        public virtual void Mapping(Profile profile)
        {
            profile.CreateMap<ProductCategory, GetByProductCategoryResponse>();
            profile.CreateMap<List<ProductCategory>, List<GetByProductCategoryResponse>>();
        }
    }
}
