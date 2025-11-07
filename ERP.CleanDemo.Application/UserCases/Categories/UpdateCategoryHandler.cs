using ERP.CleanDemo.Application.Interfaces;
using ERP.CleanDemo.Application.Requests.Categories;
using MediatR;

namespace ERP.CleanDemo.Application.UserCases.Categories;

public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand>
{
    private readonly ICategoryRepository _repo;
    public UpdateCategoryHandler(ICategoryRepository repo) => _repo = repo;

    public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var dto = request.Dto;
        var existing = await _repo.GetByIdAsync(dto.Id);
        if (existing == null)
            throw new ArgumentException($"Category {dto.Id} not found.");

        existing.Name = dto.Name;
        await _repo.UpdateAsync(existing);

        return Unit.Value;
    }
}