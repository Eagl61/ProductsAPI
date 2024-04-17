using FluentValidation;
using ProductsAPI.Endpoints.Products.Models;

namespace ProductsAPI.Endpoints.Products.Validation;

public class ProductCreatesValidator : AbstractValidator<ICollection<ProductCreateDto>>
{
    public ProductCreatesValidator()
    {
        RuleForEach(product => product).SetValidator(new ProductCreateValidator());
    }
}