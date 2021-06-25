using AutoMapper;
using Mvp24Hours.Core.Contract.Mappings;
using SimpleLogAPI.Core.Entity;
using System;

namespace SimpleLogAPI.Core.ValueObjects.ProductCategories
{
    public class GetByIdProductCategoryResponse : GetByProductCategoryResponse, IMapFrom<ProductCategory>
    {
        public virtual DateTime Created { get; set; }
        public virtual int? CreatedBy { get; set; }

        public override void Mapping(Profile profile)
        {
            profile.CreateMap<ProductCategory, GetByIdProductCategoryResponse>();
        }
    }
}
