using ERP.CleanDemo.Application.Interfaces;
using ERP.CleanDemo.Application.Requests.Products;
using MediatR;

namespace ERP.CleanDemo.Application.UserCases.Products;

public class DeleteProductHandler : IRequestHandler<DeleteProductCommand>
{
    private readonly IProductRepository _productRepo;

    public DeleteProductHandler(IProductRepository productRepo)
    {
        _productRepo = productRepo;
    }

    public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var entity = await _productRepo.GetByIdAsync(request.Id);
        if (entity == null)
            throw new KeyNotFoundException($"Product {request.Id} not found.");

        await _productRepo.DeleteAsync(entity);
        return Unit.Value;
    }
}