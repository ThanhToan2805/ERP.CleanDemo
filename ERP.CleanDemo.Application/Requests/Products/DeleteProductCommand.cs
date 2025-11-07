using MediatR;

namespace ERP.CleanDemo.Application.Requests.Products;

public record DeleteProductCommand(int Id) : IRequest;