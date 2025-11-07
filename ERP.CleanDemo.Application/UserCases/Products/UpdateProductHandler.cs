using ERP.CleanDemo.Application.Interfaces;
using ERP.CleanDemo.Application.Requests.Products;
using MediatR;

namespace ERP.CleanDemo.Application.UserCases.Products;

public class UpdateProductHandler : IRequestHandler<UpdateProductCommand>
{
    private readonly IProductRepository _productRepo;
    private readonly ICategoryRepository _categoryRepo;

    public UpdateProductHandler(IProductRepository productRepo, ICategoryRepository categoryRepo)
    {
        _productRepo = productRepo;
        _categoryRepo = categoryRepo;
    }

    public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var dto = request.Dto;
        var entity = await _productRepo.GetByIdAsync(dto.Id);
        if (entity == null)
            throw new KeyNotFoundException($"Product {dto.Id} not found.");

        if (!await _categoryRepo.ExistsAsync(dto.CategoryId))
            throw new ArgumentException($"Category {dto.CategoryId} not found.");

        entity.Name = dto.Name;
        entity.Price = dto.Price;
        entity.CategoryId = dto.CategoryId;

        await _productRepo.UpdateAsync(entity);
        return Unit.Value;
    }
}