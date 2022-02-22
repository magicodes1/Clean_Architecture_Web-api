using FluentValidation;

namespace Delicious.core
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
           RuleFor(x=>x.CategoryName).NotEmpty().NotNull();
        }
    }
}