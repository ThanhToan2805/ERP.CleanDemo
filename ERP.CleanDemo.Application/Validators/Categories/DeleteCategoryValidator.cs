using ERP.CleanDemo.Application.Requests.Categories;
using FluentValidation;

namespace ERP.CleanDemo.Application.Validators.Categories
{
    public class DeleteCategoryValidator : AbstractValidator<DeleteCategoryCommand>
    {
        public DeleteCategoryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Category ID must be greater than 0.");
        }
    }
}