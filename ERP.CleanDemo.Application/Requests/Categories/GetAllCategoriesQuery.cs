using ERP.CleanDemo.Contracts.DTOs;
using MediatR;

namespace ERP.CleanDemo.Application.Requests.Categories;

public record GetAllCategoriesQuery() : IRequest<IEnumerable<CategoryDto>>;