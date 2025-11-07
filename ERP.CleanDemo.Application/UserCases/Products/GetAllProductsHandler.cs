using ERP.CleanDemo.Application.Interfaces;
using ERP.CleanDemo.Application.Requests.Products;
using ERP.CleanDemo.Contracts.DTOs;
using MediatR;

namespace ERP.CleanDemo.Application.UserCases.Products;

public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductDto>>
{
    private readonly IProductRepository _productRepo;

    public GetAllProductsHandler(IProductRepository productRepo)
    {
        _productRepo = productRepo;
    }

    public async Task<IEnumerable<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _productRepo.GetAllAsync();
        return products.Select(p => new ProductDto(p.Id, p.Name, p.Price, p.CategoryId));
    }
}