using Application.BaseData;
using Application.BaseData.Dto;
using Application.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text.Json;

namespace SaleInWeb.Pages.BaseData
{
    public class UnitMeasurementModel : PageModel
    {
        private readonly IBaseDataService _service;
        public EditUnit Command;
        public CreateUnit Command1;
        public UnitMeasurementModel(IBaseDataService service)
        {
            _service = service;
        }

        public void OnGet() { }

        public IActionResult OnPost(CreateUnit command1)
        {
            return new JsonResult(_service.CreateUnit(command1));
        }
        public IActionResult OnGetData(JqueryDatatableParam param)
        {
           var result= _service.GetAllUnit(param);
           return result;
           return new JsonResult(result, new JsonSerializerOptions { PropertyNamingPolicy = null });
        }


        public IActionResult OnGetRemove(Guid id, JqueryDatatableParam param)
        {
            return new JsonResult(_service.RemoveUnit(id));
        }


        public IActionResult OnPostEdit(EditUnit command)
        {
            return new JsonResult(_service.UpdateUnit(command));
        }
    }
}

