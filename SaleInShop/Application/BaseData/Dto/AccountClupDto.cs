using System.Collections;
using System.ComponentModel.DataAnnotations;
using Domain.ShopModels;
using Guid = System.Guid;

namespace Application.BaseData.Dto
{
    public class CreateAccountClub
    {
        public Guid AccClbUid { get; set; } = Guid.NewGuid();
        public string AccClbName { get; set; }
        public string AccClbCode { get; set; }

        //public Guid? AccUid { get; set; }

        public Guid? AccRateUid { get; set; }

        public string AccClbNationalCode { get; set; }

        public string AccClbPostalCode { get; set; }

        public string AccClbPhone1 { get; set; }

        public string AccClbPhone2 { get; set; }

        public string AccClbMobile { get; set; }

        public string AccClbMobile2 { get; set; }
        public string ShamsiBirthDay { get; set; }
        public DateTime? AccClbBrithday { get; set; }

        public Guid? AccClbParentUid { get; set; }
        public Guid? CityUid { get; set; }
        public Guid? SateUid { get; set; }

        public Guid? AccClbTypUid { get; set; }

        public int? AccClbSex { get; set; }

        public string AccClbAddress { get; set; }

        public string AccClbDescribtion { get; set; }

        public string AccClbAddress2 { get; set; }

        public string AccClbPassword { get; set; }

        public string AccClbLat { get; set; }

        public string AccClbLong { get; set; }

        [Compare("AccClbPassword", ErrorMessage = "رمز عبور با تکرار آن مغایرت دارد.")]
        public string AccClbConfirmPassword { get; set; }
    }


    public class AccountClubDto
    {
        public Guid AccClbUid { get; set; }
        public DateTime? AccClbBrithday { get; set; }
        public string ShamsiBirthDay { get; set; }
        public string AccClbName { get; set; }
        public string AccClbCode { get; set; }
        public int? AccTypePriceLevel { get; set; }
        public string AccTypePriceLevelText { get; set; }
        public bool IsPriceLevel { get; set; }
        public Guid? AccRateUid { get; set; }
        public Guid? AccClbTypUid { get; set; }
        public string AccClbNationalCode { get; set; }
        public string AccClbPostalCode { get; set; }
        public string AccClbPhone1 { get; set; }
        public string AccClbPhone2 { get; set; }
        public string AccClubType { get; set; }
        public double AccClubDiscount { get; set; }
        public string AccRatioText { get; set; }
        public string AccClbMobile { get; set; }
        public int? AccClbSex { get; set; }
        public string AccClbSexText { get; set; }
        public string AccClbAddress { get; set; }
        public double? InvoiceDiscount { get; set; }
        public decimal TotalPaidAmount { get;}
      
    }

    public class EditAccountClub : CreateAccountClub
    {
        public List<AccountSelectOption> Account { get; set; }
        public List<AccountRating> Rating { get; set; }
        public List<AccountClubType> ClupType { get; set; }
        public List<SelectListOption> States { get; set; }
        public List<SelectListOption> Cities { get; set; }
    }
}
