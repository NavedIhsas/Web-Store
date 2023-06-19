using System.ComponentModel.DataAnnotations;
using Application.Common;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Application.BaseData.Dto
{
    public class CreateUnit
    {
        public CreateUnit()=> Id = Guid.NewGuid();
        public Guid Id{ get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public bool Status { get; set; } = true;
    }

    public class EditUnit : CreateUnit
    {
        public EditUnit()=> Id = Guid.NewGuid();
    }
    public class UnitDto : CreateUnit { }

    public class CreateWareHouse
    {
        public Guid Id { get; set; }=Guid.NewGuid();
        public string Name { get; set; }
        public string Code { get; set; }
        public bool Status { get; set; } = true;
    }

    public class UpdateWareHouse : CreateWareHouse
    {
        public UpdateWareHouse() => Id = Guid.NewGuid();
    }


    public class WareHouseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public bool Status { get; set; } = true;
    }


    public class CreateAccountClubType
    {
        public Guid Id { get; set; }=Guid.NewGuid();
        public string Name { get; set; }
        public string DiscountType { get; set; }
        public bool Status { get; set; } = true;
        /// <summary>
        /// قیمت کالا
        /// </summary>
        
        [Range(1,Int32.MaxValue,ErrorMessage ="این مقدار نمیتواند خالی باشد")]
        public int? PriceInvoice { get; set; }
        /// <summary>
        /// درصد تخفیف
        /// </summary>
        public double? PercentDiscount { get; set; }
        /// <summary>
        /// تخفیف شعبه
        /// </summary>
        public double? DetDiscount { get; set; }
    }

    public class UpdateAccountClubType : CreateAccountClubType
    {
        public UpdateAccountClubType()
        {
            Id = new Guid();
        }
    }

    public class AccountClubTypeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string DiscountType { get; set; }
        public string DiscountTypeText { get; set; }
        public bool Status { get; set; }
        /// <summary>
        /// قیمت کالا
        /// </summary>
        public int PriceInvoice { get; set; }
        public string PriceInvoiceText { get; set; }
        /// <summary>
        /// درصد تخفیف
        /// </summary>
        public double? PercentDiscount { get; set; }
        /// <summary>
        /// تخفیف شعبه
        /// </summary>
        public double? DetDiscount { get; set; }
    }
   


    public class CreateAccountRating
    {
        public Guid Id { get; set; }=Guid.NewGuid();
        public string Name { get; set; }
    }
    public class UpdateAccountRating:CreateAccountRating
    {
        public UpdateAccountRating()
        {
            Id = new Guid();
        }
       
    }
    public class AccountRatingDto
    {
        public Guid Id { get; set; }=Guid.NewGuid();
        public string Name { get; set; }
    }
}
