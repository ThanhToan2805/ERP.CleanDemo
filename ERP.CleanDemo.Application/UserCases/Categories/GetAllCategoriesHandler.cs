using ERP.CleanDemo.Application.Interfaces;
using ERP.CleanDemo.Application.Requests.Categories;
using ERP.CleanDemo.Contracts.DTOs;
using MediatR;

namespace ERP.CleanDemo.Application.UserCases.Categories;

public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesQuery, IEnumerable<CategoryDto>>
{
    private readonly ICategoryRepository _repo;
    public GetAllCategoriesHandler(ICategoryRepository repo) => _repo = repo;

    public async Task<IEnumerable<CategoryDto>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await _repo.GetAllAsync();
        return categories.Select(c => new CategoryDto(c.Id, c.Name));
    }
}