using Application.Common;
using FluentValidation;
using static Application.Product.Category.ProductCategory;

namespace Application.Product.Category;

public class CategoryPrdValidator : AbstractValidator<CreateProductLevel>
{
    public CategoryPrdValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage(ValidateMessage.Required);
    }
}