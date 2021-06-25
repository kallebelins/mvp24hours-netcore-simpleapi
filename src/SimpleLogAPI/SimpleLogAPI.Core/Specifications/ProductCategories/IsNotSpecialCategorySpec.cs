using Mvp24Hours.Core.Contract.Domain.Specifications;
using SimpleLogAPI.Core.Entity;
using System;
using System.Linq.Expressions;

namespace SimpleLogAPI.Core.Specifications.ProductCategories
{
    public class IsNotSpecialCategorySpec : ISpecificationValidator<ProductCategory>, ISpecificationQuery<ProductCategory>
    {
        public string KeyValidation => "IsNotSpecialCategory";

        public string MessageValidation => "Special category.";

        public Expression<Func<ProductCategory, bool>> IsSatisfiedByExpression => (x) => x.Id != 1;
    }
}
