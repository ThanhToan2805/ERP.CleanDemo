using ERP.CleanDemo.Application.Interfaces;
using ERP.CleanDemo.Application.Requests.Categories;
using MediatR;

namespace ERP.CleanDemo.Application.UserCases.Categories;

public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand>
{
    private readonly ICategoryRepository _repo;
    public DeleteCategoryHandler(ICategoryRepository repo) => _repo = repo;

    public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repo.GetByIdAsync(request.Id);
        if (entity == null)
            throw new ArgumentException($"Category {request.Id} not found.");

        await _repo.DeleteAsync(entity);

        return Unit.Value;
    }
}