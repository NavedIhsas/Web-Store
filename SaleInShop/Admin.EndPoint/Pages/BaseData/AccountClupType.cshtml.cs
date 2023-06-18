using Application.BaseData.Dto;
using Application.BaseData;
using Application.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SaleInWeb.Pages.BaseData
{
    public class AccountClupTypeModel : PageModel
    {
        private readonly IBaseDataService _service;
        public UpdateAccountClubType Command;
        public CreateAccountClubType Command1;
        public AccountClupTypeModel(IBaseDataService service)
        {
            _service = service;
        }

        public void OnGet() { }

        public IActionResult OnPost(CreateAccountClubType command1)
        {
            return new JsonResult(_service.CreateAccountClubType(command1));
        }
        public IActionResult OnGetData(JqueryDatatableParam param)
        {
            var result = _service.GetAllAccountClupType(param);
            return result;

        }


        public IActionResult OnGetRemove(Guid id)
        {
            return new JsonResult(_service.RemoveAccountClubType(id));
        }


        public IActionResult OnPostEdit(UpdateAccountClubType command)
        {
            return new JsonResult(_service.UpdateAccountClubType(command));
        }
    }
}
