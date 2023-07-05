using Application.Common;
using Application.Invoice;
using Application.Product;
using Application.Product.Category;
using Application.Product.ProductDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SaleInWeb.Pages.Invoice
{
    public class PreInvoiceModel : PageModel
    {
        private readonly IProductCategory _category;
        private readonly IInvoiceService _invoiceService;
        private readonly IProductService _product;

        public string Message = "";
        public PreInvoiceModel(IProductCategory category, IInvoiceService invoiceService, IProductService product)
        {
            _category = category;
            _invoiceService = invoiceService;
            _product = product;
        }

        public List<ProductCategory.ProductLevelDto> Categories;
        public List<ProductDto> Products;
        public void OnGet()
        {
            Categories = _category.GetLevelList();
        }

        public IActionResult OnPost()
        {
            return new JsonResult(_invoiceService.Create());
        }
        public JsonResult OnGetData(JqueryDatatableParam param)
        {
            var result = _product.GetAllProductForInvoice(param);
            if (result.IsSucceeded)
                return result.Data;
            else
            {
                Message = result.Message;
                return new JsonResult(result.Message);
            }
        }

        public IActionResult OnGetInvoiceList(JqueryDatatableParam param)
        {
            return _invoiceService.GetInvoiceList(param);
        }

        public IActionResult OnGetInvoiceDetails(Guid invoiceId) => new JsonResult(_invoiceService.InvoiceDetails(invoiceId));
        public IActionResult OnGetProductToList(Guid id) => new JsonResult(_invoiceService.ProductToList(id));
        public IActionResult OnGetRemoveFromProductList(Guid id) => new JsonResult(_invoiceService.RemoveFromProductList(id));
    }
}
