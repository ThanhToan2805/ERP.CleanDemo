using ERP.CleanDemo.Contracts.DTOs;
using MediatR;

namespace ERP.CleanDemo.Application.Requests.Products;

public record GetProductsByCategoryQuery(int CategoryId) : IRequest<IEnumerable<ProductDto>>;