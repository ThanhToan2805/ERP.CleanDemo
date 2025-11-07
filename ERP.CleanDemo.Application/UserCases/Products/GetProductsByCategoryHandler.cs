using ERP.CleanDemo.Application.Interfaces;
using ERP.CleanDemo.Application.Requests.Products;
using ERP.CleanDemo.Contracts.DTOs;
using MediatR;

namespace ERP.CleanDemo.Application.UserCases.Products;

public class GetProductsByCategoryHandler : IRequestHandler<GetProductsByCategoryQuery, IEnumerable<ProductDto>>
{
    private readonly IProductRepository _productRepo;

    public GetProductsByCategoryHandler(IProductRepository productRepo)
    {
        _productRepo = productRepo;
    }

    public async Task<IEnumerable<ProductDto>> Handle(GetProductsByCategoryQuery request, CancellationToken cancellationToken)
    {
        var products = await _productRepo.GetByCategoryIdAsync(request.CategoryId);
        return products.Select(p => new ProductDto(p.Id, p.Name, p.Price, p.CategoryId));
    }
}