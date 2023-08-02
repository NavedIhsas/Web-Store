using Application.Common;
using Application.Invoice;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SaleInWeb.Pages.Invoice
{
    public class TrackModel : PageModel
    {

        private readonly IInvoiceService _invoiceService;
        public JqueryTrackDataTableParam Model;

        public TrackModel(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        public void OnGet()
        {
        }

        public IActionResult OnGetData(JqueryTrackDataTableParam param)
        {
           return _invoiceService.GetTrackInvoice(param);
        
           // return new JsonResult(result);
        }
    }
}
