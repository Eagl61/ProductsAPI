using ProductsAPI.Constants;

namespace ProductsAPI.Endpoints.Products.Models;

public class ProductCreateDto
{
    public string Name { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public Currency Currency { get; set; }
}