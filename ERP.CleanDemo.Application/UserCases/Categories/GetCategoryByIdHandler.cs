using ERP.CleanDemo.Application.Interfaces;
using ERP.CleanDemo.Application.Requests.Categories;
using ERP.CleanDemo.Contracts.DTOs;
using MediatR;

namespace ERP.CleanDemo.Application.UserCases.Categories;

public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdQuery, CategoryDto?>
{
    private readonly ICategoryRepository _repo;
    public GetCategoryByIdHandler(ICategoryRepository repo) => _repo = repo;

    public async Task<CategoryDto?> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var c = await _repo.GetByIdAsync(request.Id);
        return c == null ? null : new CategoryDto(c.Id, c.Name);
    }
}