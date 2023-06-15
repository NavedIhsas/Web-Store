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

        public UnitMeasurementModel(IBaseDataService service)
        {
            _service = service;
        }

        public void OnGet() { }
        public IActionResult OnGetData(JqueryDatatableParam param)
        {
           var result= _service.GetAllUnit(param);
           return result;
           return new JsonResult(result, new JsonSerializerOptions { PropertyNamingPolicy = null });
        }
    }
}

