using ERP.CleanDemo.Application.Interfaces;
using ERP.CleanDemo.Application.Requests.Categories;
using ERP.CleanDemo.Contracts.DTOs;
using ERP.CleanDemo.Domain.Entities;
using MediatR;

namespace ERP.CleanDemo.Application.UserCases.Categories;

public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, CategoryDto>
{
    private readonly ICategoryRepository _repo;
    public CreateCategoryHandler(ICategoryRepository repo) => _repo = repo;

    public async Task<CategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = new Category { Name = request.Dto.Name };
        await _repo.AddAsync(entity);
        return new CategoryDto(entity.Id, entity.Name);
    }
}