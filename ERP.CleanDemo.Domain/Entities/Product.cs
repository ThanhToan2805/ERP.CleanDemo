namespace ERP.CleanDemo.Domain.Entities;
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public decimal Price { get; set; }

    // Foreign key
    public int CategoryId { get; set; }

    // Navigation
    public Category? Category { get; set; }
}