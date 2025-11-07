using ERP.CleanDemo.Contracts.DTOs;
using MediatR;

namespace ERP.CleanDemo.Application.Requests.Categories;

public record CreateCategoryCommand(CategoryCreateDto Dto) : IRequest<CategoryDto>;