namespace ERP.CleanDemo.Contracts.DTOs;

public record ProductDto(int Id, string Name, decimal Price, int CategoryId);
public record ProductCreateDto(string Name, decimal Price, int CategoryId);
public record ProductUpdateDto(int Id, string Name, decimal Price, int CategoryId);