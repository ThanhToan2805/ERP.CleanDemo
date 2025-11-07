using ERP.CleanDemo.Application.Requests.Products;
using FluentValidation;

namespace ERP.CleanDemo.Application.Products.Validators;

public class DeleteProductValidator : AbstractValidator<DeleteProductCommand>
{
    public DeleteProductValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Product Id must be valid.");
    }
}