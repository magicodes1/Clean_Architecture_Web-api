using FluentValidation;

namespace Delicious.core
{
    public class CategoryDTOValidator : AbstractValidator<CategoryDTO>
    {
        public CategoryDTOValidator()
        {
           RuleFor(x=>x.CategoryName).NotEmpty().NotNull();
           RuleFor(x=>x.id).NotEmpty().NotNull();
        }
    }
}