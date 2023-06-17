using Application.BaseData.Dto;
using Application.BaseData;
using Application.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace SaleInWeb.Pages.BaseData
{
    public class WareHouseModel : PageModel
    {
        private readonly IBaseDataService _service;
        public UpdateWareHouse Command;
        public CreateWareHouse Command1;
        public WareHouseModel(IBaseDataService service)
        {
            _service = service;
        }

        public void OnGet() { }

        public IActionResult OnPost(CreateWareHouse command1)
        {
            return new JsonResult(_service.CreateWareHouse(command1));
        }
        public IActionResult OnGetData(JqueryDatatableParam param)
        {
            var result = _service.GetAllWareHouse(param);
            return result;
            
        }


        public IActionResult OnGetRemove(Guid id)
        {
            return new JsonResult(_service.RemoveWareHouse(id));
        }


        public IActionResult OnPostEdit(UpdateWareHouse command)
        {
            return new JsonResult(_service.UpdateWareHouse(command));
        }
    }
}
