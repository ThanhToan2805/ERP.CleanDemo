using ERP.CleanDemo.Application.Requests.Products;
using FluentValidation;

namespace ERP.CleanDemo.Application.Products.Validators;

public class CreateProductValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductValidator()
    {
        RuleFor(x => x.Dto.Name)
            .NotEmpty().WithMessage("Product name is required.")
            .MaximumLength(200);

        RuleFor(x => x.Dto.Price)
            .GreaterThan(0).WithMessage("Price must be greater than 0.");

        RuleFor(x => x.Dto.CategoryId)
            .GreaterThan(0).WithMessage("CategoryId must be valid.");
    }
}