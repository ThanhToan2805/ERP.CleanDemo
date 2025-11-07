using ERP.CleanDemo.Application.Requests.Categories;
using FluentValidation;

namespace ERP.CleanDemo.Application.Validators.Categories;

public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryValidator()
    {
        RuleFor(x => x.Dto.Id)
            .GreaterThan(0);

        RuleFor(x => x.Dto.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(200);
    }
}