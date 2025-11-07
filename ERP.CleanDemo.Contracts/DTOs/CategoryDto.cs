namespace ERP.CleanDemo.Contracts.DTOs;

public record CategoryDto(int Id, string Name);
public record CategoryCreateDto(string Name);
public record CategoryUpdateDto(int Id, string Name);