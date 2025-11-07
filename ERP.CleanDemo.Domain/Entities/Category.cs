namespace ERP.CleanDemo.Domain.Entities;
public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    // Navigation: 1 Category có nhiều Products
    public ICollection<Product> Products { get; set; } = new List<Product>();
}