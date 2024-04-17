using FluentValidation;
using ProductsAPI.Endpoints.Products.Models;

namespace ProductsAPI.Endpoints.Products.Validation;

public class ProductCreateValidator : AbstractValidator<ProductCreateDto>
{
    public ProductCreateValidator()
    {
        RuleFor(product => product.Name)
            .MaximumLength(100)
            .NotNull()
            .NotEmpty();
        RuleFor(product => product.Description)
            .MaximumLength(250)
            .NotNull();
        RuleFor(product => product.Currency)
            .IsInEnum();
    }
}