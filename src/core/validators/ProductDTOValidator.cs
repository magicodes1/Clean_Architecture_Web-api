using FluentValidation;

namespace Delicious.core
{
    public class ProductDTOValidator : AbstractValidator<ProductDTO>
    {
        public ProductDTOValidator()
        {
            RuleFor(x=>x.id).NotEmpty().NotNull();
            RuleFor(x=>x.ProductName).MaximumLength(50).NotEmpty().NotNull();
            RuleFor(x=>x.Price).GreaterThan(0).NotNull();
            RuleFor(x=>x.Sale).InclusiveBetween(0,100).NotEmpty().NotNull();
            
            RuleFor(x=>x.Images).MaximumLength(100);

            RuleFor(x=>x.CategoryId).NotEmpty().NotNull();
        }
    }
}