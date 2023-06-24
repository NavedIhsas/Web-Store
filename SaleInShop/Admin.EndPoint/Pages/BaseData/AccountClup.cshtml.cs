using Application.BaseData;
using Application.BaseData.Dto;
using Domain.ShopModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SaleInWeb.Pages.BaseData
{
    public class AccountClupModel : PageModel
    {
        private readonly IBaseDataService _service;
        public CreateAccountClup Command;
        public List<AccountSelectOption> Account;
        public List<AccountRating> Rating;
        public List<AccountClubType> ClupType;

        public AccountClupModel(IBaseDataService service)
        {
            _service = service;
        }

        public void OnGet()
        {
            Account = _service.GetSelectOptionAccounts();
            Rating = _service.GetSelectOptionRatings();
            ClupType = _service.GetSelectOptionClubTypes();
        }

        public void OnPost(CreateAccountClup command) 
        {

        }
    }
}
