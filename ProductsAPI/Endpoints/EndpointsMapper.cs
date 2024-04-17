using ProductsAPI.Endpoints.Products;

namespace ProductsAPI.Endpoints;

public static class EndpointsMapper
{
    public static void MapProducts(this WebApplication app)
    {
        var productGroup = app.MapGroup("product");
        productGroup.MapPost(string.Empty, ProductEndpoints.CreateProduct);
        productGroup.MapGet("{id:int}", ProductEndpoints.GetProduct);
        productGroup.MapPut(string.Empty, ProductEndpoints.PutProduct);
        productGroup.MapDelete("{id:int}", ProductEndpoints.DeleteProduct);

        var productsGroup = app.MapGroup("products");
        productsGroup.MapPost(string.Empty, ProductEndpoints.CreateProducts);
        productsGroup.MapGet(string.Empty, ProductEndpoints.GetProducts);
        productsGroup.MapPut(string.Empty, ProductEndpoints.PutProducts);
        productsGroup.MapDelete(string.Empty, ProductEndpoints.DeleteProducts);
    }
}