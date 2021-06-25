using Mvp24Hours.Core.Contract.Domain.Specifications;
using SimpleLogAPI.Core.Entity;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace SimpleLogAPI.Core.Specifications.ProductCategories
{
    public class CategoryHasNotProductSpec : ISpecificationValidator<ProductCategory>, ISpecificationQuery<ProductCategory>
    {
        public string KeyValidation => "CategoryHasNotProduct";

        public string MessageValidation => "Category has products.";

        public Expression<Func<ProductCategory, bool>> IsSatisfiedByExpression => (x) => !x.Products.Any();
    }
}
