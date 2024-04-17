using Microsoft.EntityFrameworkCore;
using ProductsAPI.Database;
using ProductsAPI.Endpoints.Products.Models;
using ProductsAPI.Helpers;
using ProductsAPI.Mapping;
using ProductsAPI.Services.Interfaces;

namespace ProductsAPI.Services;

public class ProductService : IProductService
{
    private readonly ProductDbContext _productDbContext;

    public ProductService(ProductDbContext productDbContext)
    {
        _productDbContext = productDbContext;
    }

    public async Task CreateProductsAsync(ICollection<ProductCreateDto> products)
    {
        _productDbContext.Products.AddRange(products.Select(ProductMappingExtensions.ToProduct));
        await _productDbContext.SaveChangesAsync();
    }

    public async Task CreateProductAsync(ProductCreateDto product)
    {
        _productDbContext.Products.Add(product.ToProduct());
        await _productDbContext.SaveChangesAsync();
    }

    public async Task<ErrorOr<int>> PutProductAsync(ProductPutDto productToPut)
    {
        _productDbContext.Products.Update(productToPut.ToProduct());
        await _productDbContext.SaveChangesAsync();
        return productToPut.Id;
    }

    public async Task<ErrorOr<bool>> PutProductsAsync(ICollection<ProductPutDto> productsToUpdate)
    {
        _productDbContext.Products.UpdateRange(productsToUpdate.Select(ProductMappingExtensions.ToProduct));
        await _productDbContext.SaveChangesAsync();
        return true;
    }

    public async Task<ErrorOr<ProductGetDto>> GetProductAsync(int id)
    {
        var product = await _productDbContext.Products.FindAsync(id);
        return product is null
            ? ApiErrorMessages.NotFound()
            : product.ToProductGetDto();
    }

    public async Task<IEnumerable<ProductGetDto>> GetProductsAsync()
    {
        var products = await _productDbContext.Products.AsNoTracking().ToListAsync();
        return products.Select(ProductMappingExtensions.ToProductGetDto);
    }

    public async Task<ErrorOr<int>> DeleteProductAsync(int id)
    {
        var rowsAffected = await _productDbContext.Products
            .Where(x => x.Id == id)
            .ExecuteDeleteAsync();
        if (rowsAffected == 0)
        {
            return ApiErrorMessages.NotFound();
        }

        return id;
    }

    public async Task<ErrorOr<bool>> DeleteProductsAsync(ICollection<int> ids)
    {
        var rowsAffected = await _productDbContext.Products
            .Where(x => ids.Contains(x.Id))
            .ExecuteDeleteAsync();
        if (rowsAffected == 0)
        {
            return ApiErrorMessages.NotFound();
        }

        return true;
    }
}