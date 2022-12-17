using FluentValidation;
using ProjectA.Application.DTOs.Categories;

namespace ProjectA.Application.Validators.Categories
{
    public class CreateCategoryValidator:AbstractValidator<DTO_CreateCategory>
    {
        public CreateCategoryValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .NotNull()
                .MaximumLength(100)
                .MinimumLength(5);
        }
    }
}
