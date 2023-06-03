using System.Data;
using Application.Common;
using FluentValidation;
using static Application.Product.Category.ProductCategory;

namespace Application.Product
{
    public class CreateProductValidate : AbstractValidator<CreateProduct>
    {
        public CreateProductValidate()
        {
            RuleFor(x=>x.PrdCode).NotNull().NotEmpty().WithMessage(ValidateMessage.Required);
            RuleFor(x=>x.PrdName).NotNull().WithMessage(ValidateMessage.Required);
            RuleFor(x=>x.PrdLvlUid3).NotNull().Must(NotZero).WithMessage(ValidateMessage.Required);


        }

        private bool NotZero(Guid? arg)
        {
            if (arg == null) return false;
            var lvlUid = arg.ToString();
            return lvlUid != "0";
        }

    }


    public class CreatePropertyValidate : AbstractValidator<CreateProperty>
    {
        public CreatePropertyValidate()
        {
           // RuleFor(x=>x.Name).NotEmpty().WithMessage(ValidateMessage.Required);
            RuleFor(x=>x.Value).NotEmpty().WithMessage(ValidateMessage.Required);
            RuleFor(x=>x.Id).NotEmpty().WithMessage(ValidateMessage.Required);
            
        }
    }
}
