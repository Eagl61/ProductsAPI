using FluentValidation;
using ProductsAPI.Endpoints.Products.Models;

namespace ProductsAPI.Endpoints.Products.Validation;

public class ProductPutsValidator : AbstractValidator<ICollection<ProductPutDto>>
{
    public ProductPutsValidator()
    {
        RuleForEach(product => product).SetValidator(new ProductPutValidator());
    }
}