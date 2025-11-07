using ERP.CleanDemo.Application.Requests.Categories;
using FluentValidation;

namespace ERP.CleanDemo.Application.Validators.Categories;

public class CreateCategoryValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryValidator()
    {
        RuleFor(x => x.Dto.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(200);
    }
}