using FluentValidation;
using static Application.Product.Category.ProductCategory;

namespace Application.Product
{
    public class ProductValidate : AbstractValidator<CreateProduct>
    {
    }
}
