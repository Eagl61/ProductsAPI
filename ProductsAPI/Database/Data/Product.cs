using ProductsAPI.Constants;

namespace ProductsAPI.Database.Data;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public Currency Currency { get; set; } = Currency.USD;
    public Guid Version { get; set; }
}