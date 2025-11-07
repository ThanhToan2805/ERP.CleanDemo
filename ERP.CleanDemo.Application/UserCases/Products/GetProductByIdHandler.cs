using ERP.CleanDemo.Application.Interfaces;
using ERP.CleanDemo.Application.Requests.Products;
using ERP.CleanDemo.Contracts.DTOs;
using MediatR;

namespace ERP.CleanDemo.Application.UserCases.Products;

public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductDto?>
{
    private readonly IProductRepository _productRepo;

    public GetProductByIdHandler(IProductRepository productRepo)
    {
        _productRepo = productRepo;
    }

    public async Task<ProductDto?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var p = await _productRepo.GetByIdAsync(request.Id);
        return p == null ? null : new ProductDto(p.Id, p.Name, p.Price, p.CategoryId);
    }
}