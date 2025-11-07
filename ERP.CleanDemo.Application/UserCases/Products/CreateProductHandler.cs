using ERP.CleanDemo.Application.Interfaces;
using ERP.CleanDemo.Application.Requests.Products;
using ERP.CleanDemo.Contracts.DTOs;
using ERP.CleanDemo.Domain.Entities;
using MediatR;

namespace ERP.CleanDemo.Application.UserCases.Products;

public class CreateProductHandler : IRequestHandler<CreateProductCommand, ProductDto>
{
    private readonly IProductRepository _productRepo;
    private readonly ICategoryRepository _categoryRepo;

    public CreateProductHandler(IProductRepository productRepo, ICategoryRepository categoryRepo)
    {
        _productRepo = productRepo;
        _categoryRepo = categoryRepo;
    }

    public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var dto = request.Dto;
        if (!await _categoryRepo.ExistsAsync(dto.CategoryId))
            throw new ArgumentException($"Category {dto.CategoryId} not found.");

        var entity = new Product { Name = dto.Name, Price = dto.Price, CategoryId = dto.CategoryId };
        await _productRepo.AddAsync(entity);

        return new ProductDto(entity.Id, entity.Name, entity.Price, entity.CategoryId);
    }
}