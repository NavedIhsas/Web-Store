using Application.BaseData.Dto;
using Application.BaseData;
using Application.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace SaleInWeb.Pages.BaseData
{
    public class AccountRatingModel : PageModel
    {
        private readonly IBaseDataService _service;
        public UpdateAccountRating Command;
        public CreateAccountRating Command1;
        public AccountRatingModel(IBaseDataService service)
        {
            _service = service;
        }

        public void OnGet() { }

        public IActionResult OnPost(CreateAccountRating command1)
        {
            return new JsonResult(_service.CreateAccountRating(command1));
        }
        public IActionResult OnGetData(JqueryDatatableParam param)
        {
            var result = _service.GetAllAccountRating(param);
            return result;
            return new JsonResult(result, new JsonSerializerOptions { PropertyNamingPolicy = null });
        }


        public IActionResult OnGetRemove(Guid id, JqueryDatatableParam param)
        {
            return new JsonResult(_service.RemoveAccountRating(id));
        }


        public IActionResult OnPostEdit(UpdateAccountRating command)
        {
            return new JsonResult(_service.UpdateAccountRating(command));
        }
    }
}
