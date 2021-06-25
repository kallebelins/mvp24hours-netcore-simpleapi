using Mvp24Hours.Core.Contract.Domain.Specifications;
using SimpleLogAPI.Core.Entity;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace SimpleLogAPI.Core.Specifications.Products
{
    public class SpecialCategoryAllowsOneProductSpec : ISpecificationValidator<Product>, ISpecificationQuery<Product>
    {
        #region [ Ctors ]

        public SpecialCategoryAllowsOneProductSpec(Product model)
            => Model = model ?? throw new ArgumentNullException("Model is required.");

        #endregion

        #region [ Fields ]

        protected readonly Product Model;

        public string KeyValidation => "CategoryAllowsOnlyOneProduct";
        public string MessageValidation => "This category allows only one product.";

        public Expression<Func<Product, bool>> IsSatisfiedByExpression => (x) =>
            x.ProductCategoryId == 1
            && (Model.Id == 0 || x.Id != Model.Id)
            && !x.Category.Products.Any();

        #endregion

    }
}
