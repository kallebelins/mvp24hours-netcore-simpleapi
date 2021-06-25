﻿using AutoMapper;
using Mvp24Hours.Core.Contract.Mappings;
using Mvp24Hours.Core.ValueObjects;
using SimpleAPI.Core.Entity;
using System.Collections.Generic;

namespace SimpleAPI.Core.ValueObjects.ProductCategories
{
    public class CreateProductCategoryRequest : BaseVO, IMapFrom<ProductCategory>
    {
        public virtual string Name { get; set; }

        public virtual void Mapping(Profile profile)
        {
            profile.CreateMap<CreateProductCategoryRequest, ProductCategory>();
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
        }
    }
}
