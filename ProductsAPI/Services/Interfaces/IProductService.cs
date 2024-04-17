using ProductsAPI.Endpoints.Products.Models;
using ProductsAPI.Helpers;

namespace ProductsAPI.Services.Interfaces;

public interface IProductService
{
    Task CreateProductAsync(ProductCreateDto product);
    Task CreateProductsAsync(ICollection<ProductCreateDto> products);
    Task<ErrorOr<ProductGetDto>> GetProductAsync(int id);
    Task<IEnumerable<ProductGetDto>> GetProductsAsync();
    Task<ErrorOr<int>> PutProductAsync(ProductPutDto productToPut);
    Task<ErrorOr<bool>> PutProductsAsync(ICollection<ProductPutDto> productsToUpdate);
    Task<ErrorOr<int>> DeleteProductAsync(int id);
    Task<ErrorOr<bool>> DeleteProductsAsync(ICollection<int> ids);
}