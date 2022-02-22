using FluentValidation;

namespace Delicious.core
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            //RuleFor(x=>x.Id).GreaterThan(0);
            RuleFor(x=>x.ProductName).MaximumLength(50).NotEmpty().NotNull();
            RuleFor(x=>x.Price).GreaterThan(0).NotNull();
            RuleFor(x=>x.Sale).InclusiveBetween(0,100).NotEmpty().NotNull();
            
            RuleFor(x=>x.Images).MaximumLength(100);

            RuleFor(x=>x.CategoryId).NotEmpty().NotNull();
        }
    }
}