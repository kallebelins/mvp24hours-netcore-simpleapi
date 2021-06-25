using Mvp24Hours.Core.Contract.Domain.Validations;
using SimpleAPI.Core.Entity;

namespace SimpleAPI.Core.Validators
{
    public class ProductValidator : IValidator<Product>
    {
        protected readonly IValidatorNotify<Product> Validator;

        public ProductValidator(IValidatorNotify<Product> validator)
            => Validator = validator;

        public bool Validate(Product candidate)
        {
            return Validator.Validate(candidate);
        }

    }
}
