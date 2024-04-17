using ProductsAPI.Database.Data;
using ProductsAPI.Endpoints.Products.Models;

namespace ProductsAPI.Mapping;

public static class ProductMappingExtensions
{
    public static Product ToProduct(this ProductCreateDto productDto)
        => new()
        {
            Name = productDto.Name,
            Description = productDto.Description,
            Price = productDto.Price,
            Currency = productDto.Currency
        };

    public static Product ToProduct(this ProductPutDto productDto)
        => new()
        {
            Id = productDto.Id,
            Name = productDto.Name,
            Description = productDto.Description,
            Price = productDto.Price,
            Currency = productDto.Currency
        };

    public static ProductGetDto ToProductGetDto(this Product product)
        => new()
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            Currency = product.Currency
        };
}
