using System.Data;
using Application.Common;
using Application.Interfaces;
using FluentValidation;
using static Application.Product.Category.ProductCategory;

namespace Application.Product
{
    public class CreateProductValidate : AbstractValidator<CreateProduct>
    {
        private readonly IAuthHelper _authHelper;

        public CreateProductValidate(IAuthHelper authHelper)
        {
            _authHelper = authHelper;
        }
        public CreateProductValidate()
        {
           
            RuleFor(x=>x.PrdCode).Must(CheckLength).WithMessage("اندازه کد بیش از حد مجاز هست").NotEmpty().WithMessage(ValidateMessage.Required);
            RuleFor(x=>x.PrdName).NotEmpty().WithMessage(ValidateMessage.Required);
            RuleFor(x=>x.PrdLvlUid3).NotNull().Must(NotZero).WithMessage(ValidateMessage.Required);
        }

        private bool CheckLength(string arg)
        {
            var check= _authHelper.CheckLength(arg);
            return check == true;
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
