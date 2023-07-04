using Application.BaseData;
using Application.BaseData.Dto;
using Application.Common;
using Domain.ShopModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SaleInWeb.Pages.BaseData
{
    public class CreateAccountClubModel : PageModel
    {
        private readonly IBaseDataService _service;
        public CreateAccountClub Command;
        public List<AccountSelectOption> Account;
        public List<AccountRating> Rating;
        public List<AccountClubType> ClupType;
        public List<SelectListOption> States;
        public CreateAccountClubModel(IBaseDataService service)
        {
            _service = service;
        }

        public void OnGet()
        {
            Account = _service.GetSelectOptionAccounts();
            Rating = _service.GetSelectOptionRatings();
            ClupType = _service.GetSelectOptionClubTypes();
            States = _service.SelectOptionState();
        }

        public IActionResult OnGetCities(Guid stateId)
        {
            return new JsonResult(_service.SelectOptionCities(stateId));
        }
        public IActionResult OnGetAccountClub(JqueryDatatableParam param)
        {
            return this.Partial("AccountClub", new List<AccountClubDto>());
        }
        
        public IActionResult OnGetData(JqueryDatatableParam param)=> _service.GetAllAccountClub(param);
       
        public IActionResult OnPost(CreateAccountClub command)
        {
           
            try
            {
                if (!string.IsNullOrWhiteSpace(command.ShamsiBirthDay))
                {
                    command.ShamsiBirthDay = command.ShamsiBirthDay[..10];
                    command.ShamsiBirthDay.ToGeorgianDateTime();
                }
            }
            catch (Exception)
            {
                var operation = new ResultDto();
                return new JsonResult(operation.Failed("فرمت تاریخ وارد شده درست نمیباشد"));
            }
            return new JsonResult(_service.CreateAccountClub(command));
        }


        public IActionResult OnGetDetails(Guid id)
        {
            return Partial("EditAccountClub", _service.GetDetailsAccountClub(id));
        }
        public IActionResult OnPostEdit(EditAccountClub command)
        {
            if (!ModelState.IsValid)
                return this.Page();

            try
            {
                if (!string.IsNullOrWhiteSpace(command.ShamsiBirthDay))
                {
                    command.ShamsiBirthDay = command.ShamsiBirthDay[..10];
                     command.ShamsiBirthDay.ToGeorgianDateTime();
                }
            }
            catch (Exception)
            {
                var operation = new ResultDto();
                return new JsonResult(operation.Failed("فرمت تاریخ وارد شده درست نمیباشد"));
            }

            return new JsonResult(_service.UpdateAccountClub(command));
        }


        public IActionResult OnGetRemove(Guid id)
        {
            return new JsonResult(_service.RemoveAccountClub(id));
        }
    }
}
