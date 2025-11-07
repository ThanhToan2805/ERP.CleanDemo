using ERP.CleanDemo.Contracts.DTOs;
using MediatR;

namespace ERP.CleanDemo.Application.Requests.Products;

public record GetAllProductsQuery() : IRequest<IEnumerable<ProductDto>>;