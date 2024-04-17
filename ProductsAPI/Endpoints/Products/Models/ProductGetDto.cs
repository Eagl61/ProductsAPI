using ProductsAPI.Constants;

namespace ProductsAPI.Endpoints.Products.Models;

public class ProductGetDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public Currency Currency { get; set; }
}