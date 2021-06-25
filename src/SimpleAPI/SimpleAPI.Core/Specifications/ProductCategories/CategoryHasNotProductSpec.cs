using Mvp24Hours.Core.Contract.Domain.Specifications;
using SimpleAPI.Core.Entity;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace SimpleAPI.Core.Specifications.ProductCategories
{
    public class CategoryHasNotProductSpec : ISpecificationValidator<ProductCategory>, ISpecificationQuery<ProductCategory>
    {
        public string KeyValidation => "CategoryHasNotProduct";

        public string MessageValidation => "Category has products.";

        public Expression<Func<ProductCategory, bool>> IsSatisfiedByExpression => (x) => !x.Products.Any();
    }
}
