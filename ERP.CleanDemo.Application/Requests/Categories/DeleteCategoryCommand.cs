using ERP.CleanDemo.Contracts.DTOs;
using MediatR;

namespace ERP.CleanDemo.Application.Requests.Categories;

public record DeleteCategoryCommand(int Id) : IRequest<Unit>;