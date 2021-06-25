using Mvp24Hours.Core.Contract.Domain.Specifications;
using SimpleAPI.Core.Entity;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace SimpleAPI.Core.Specifications.Products
{
    public class SpecialCategoryAllowsOneProductSpec : ISpecificationValidator<Product>, ISpecificationQuery<Product>
    {
        public string KeyValidation => "CategoryAllowsOnlyOneProduct";

        public string MessageValidation => "This category allows only one product.";

        public Expression<Func<Product, bool>> IsSatisfiedByExpression => (x) => x.ProductCategoryId == 1 && !x.Category.Products.Any();
    }
}
