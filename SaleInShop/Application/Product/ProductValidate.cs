using System.Data;
using Application.Common;
using FluentValidation;
using static Application.Product.Category.ProductCategory;

namespace Application.Product
{
    public class ProductValidate : AbstractValidator<CreateProduct>
    {
    }


    public class CreatePropertyValidate : AbstractValidator<CreateProperty>
    {
        public CreatePropertyValidate()
        {
           // RuleFor(x=>x.Name).NotEmpty().WithMessage(ValidateMessage.Required);
            RuleFor(x=>x.Value).NotEmpty().WithMessage(ValidateMessage.Required);
        }
    }
}
