using FluentValidation;
using ProductsAPI.Endpoints.Products.Models;

namespace ProductsAPI.Endpoints.Products.Validation;

public class ProductPutValidator : AbstractValidator<ProductPutDto>
{
    public ProductPutValidator()
    {
        RuleFor(product => product.Id).NotEmpty();
        RuleFor(product => product).SetValidator(new ProductCreateValidator());
    }
}