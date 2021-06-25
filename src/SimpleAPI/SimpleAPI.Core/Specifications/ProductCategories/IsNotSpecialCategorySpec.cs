using Mvp24Hours.Core.Contract.Domain.Specifications;
using SimpleAPI.Core.Entity;
using System;
using System.Linq.Expressions;

namespace SimpleAPI.Core.Specifications.ProductCategories
{
    public class IsNotSpecialCategorySpec : ISpecificationValidator<ProductCategory>, ISpecificationQuery<ProductCategory>
    {
        public string KeyValidation => "IsNotSpecialCategory";

        public string MessageValidation => "Special category.";

        public Expression<Func<ProductCategory, bool>> IsSatisfiedByExpression => (x) => x.Id != 1;
    }
}
