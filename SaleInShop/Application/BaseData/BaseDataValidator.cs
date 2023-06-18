using Application.BaseData.Dto;
using Application.Common;
using FluentValidation;

namespace Application.BaseData
{
    internal class BaseDataValidator:AbstractValidator<CreateUnit>
    {
        public BaseDataValidator()
        {
            this.RuleFor(x=>x.Name).NotEmpty().WithMessage(ValidateMessage.Required);
            this.RuleFor(x=>x.Code).NotEmpty().WithMessage(ValidateMessage.Required);
        }
    }

     internal class WareHouseValidator:AbstractValidator<CreateWareHouse>
    {
        public WareHouseValidator()
        {
            this.RuleFor(x=>x.Name).NotEmpty().WithMessage(ValidateMessage.Required);
            this.RuleFor(x=>x.Code).NotEmpty().WithMessage(ValidateMessage.Required);
        }
    }

      internal class AccountClupTypeValidator:AbstractValidator<CreateAccountClubType>
    {
        public AccountClupTypeValidator()
        {
            this.RuleFor(x=>x.Name).NotEmpty().WithMessage(ValidateMessage.Required);
            this.RuleFor(x=>x.DiscountType).NotEmpty().WithMessage(ValidateMessage.Required);
        }
    }



}
