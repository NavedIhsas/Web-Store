using FluentValidation;
using static Application.Product.Category.ProductCategory;

namespace Application.Product.Category
{

    public class CategoryPrdValidate : AbstractValidator<ProductLevelDto>
    {
        public CategoryPrdValidate()
        {
            RuleFor(x=>x.Name).NotNull().NotEmpty();
        }
    }
}
