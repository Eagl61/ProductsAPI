using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using ProductsAPI.Endpoints.Products.Models;
using ProductsAPI.Services.Interfaces;

namespace ProductsAPI.Endpoints.Products;

public static class ProductEndpoints
{
    public static async Task<IResult> CreateProduct(
        [FromBody] ProductCreateDto product,
        [FromServices] IProductService productService,
        [FromServices] IValidator<ProductCreateDto> validator)
    {
        var result = await validator.ValidateAsync(product);
        if (!result.IsValid)
        {
            return Results.ValidationProblem(result.ToDictionary());
        }

        await productService.CreateProductAsync(product);
        return Results.Ok();
    }

    public static async Task<IResult> CreateProducts(
        [FromBody] ICollection<ProductCreateDto> products,
        [FromServices] IProductService productService,
        [FromServices] IValidator<ICollection<ProductCreateDto>> validator)
    {
        var result = await validator.ValidateAsync(products);
        if (!result.IsValid)
        {
            return Results.ValidationProblem(result.ToDictionary());
        }

        await productService.CreateProductsAsync(products);
        return Results.Ok();
    }

    public static async Task<IResult> PutProduct(
        [FromBody] ProductPutDto product,
        [FromServices] IProductService productService,
        [FromServices] IValidator<ProductPutDto> validator)
    {
        var result = await validator.ValidateAsync(product);
        if (!result.IsValid)
        {
            return Results.ValidationProblem(result.ToDictionary());
        }

        var updateResult = await productService.PutProductAsync(product);
        return updateResult.IsError
            ? Results.Problem(updateResult.Problem)
            : Results.Ok();
    }

    public static async Task<IResult> PutProducts(
        [FromBody] ICollection<ProductPutDto> products,
        [FromServices] IProductService productService,
        [FromServices] IValidator<ICollection<ProductPutDto>> validator)
    {
        var result = await validator.ValidateAsync(products);
        if (!result.IsValid)
        {
            return Results.ValidationProblem(result.ToDictionary());
        }

        var updateResult = await productService.PutProductsAsync(products);
        return updateResult.IsError
            ? Results.Problem(updateResult.Problem)
            : Results.Ok();
    }

    public static async Task<IResult> GetProduct(
        int id,
        [FromServices] IProductService productService)
    {
        var productResult = await productService.GetProductAsync(id);
        return productResult.IsError
            ? Results.Problem(productResult.Problem)
            : Results.Ok(productResult.Data);
    }

    public static async Task<IResult> GetProducts(
        [FromServices] IProductService productService)
    {
        return Results.Ok(await productService.GetProductsAsync());
    }

    public static async Task<IResult> DeleteProduct(
        int id,
        [FromServices] IProductService productService)
    {
        await productService.DeleteProductAsync(id);
        return Results.Ok();
    }

    public static async Task<IResult> DeleteProducts(
        [FromBody] ICollection<int>? ids,
        [FromServices] IProductService productService)
    {
        if (ids is null || ids.Count == 0)
        {
            return Results.Problem("IDs are required");
        }

        var deleteResult = await productService.DeleteProductsAsync(ids);
        return deleteResult.IsError
            ? Results.Problem(deleteResult.Problem)
            : Results.Ok();
    }
}