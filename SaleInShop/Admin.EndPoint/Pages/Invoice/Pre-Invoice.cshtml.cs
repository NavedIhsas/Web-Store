using Application.Common;
using Application.Invoice;
using Application.Product;
using Application.Product.Category;
using Application.Product.ProductDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Primitives;
using Microsoft.Net.Http.Headers;

namespace SaleInWeb.Pages.Invoice
{
    public class PreInvoiceModel : PageModel
    {
        private readonly IProductCategory _category;
        private readonly IInvoiceService _invoiceService;
        private readonly IProductService _product;
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

        public IActionResult OnGetData(JqueryDatatableParam param)
        {
            Response.Cookies.Append("Test","SlamDost");
           var r3r= HttpContext.Request.Headers["AccountClubList"];

           StringValues values;
           HttpContext.Request.Headers.TryGetValue("Cookie", out values);
           var cookies = values.ToString().Split(';').ToList();
           var result = cookies.Select(c => new { Key = c.Split('=')[0].Trim(), Value = c.Split('=')[1].Trim() }).ToList();
           var username = result.FirstOrDefault(r => r.Key == "AccountClubList")?.Value;

            var get= Request.Cookies["AccountClubList"];
            var rrr = Request.Cookies.ContainsKey("AccountClubList");
            var rr =Request.Cookies["AccountClubList"];
            return _product.GetAllProductForInvoice(param);
        }

        public IActionResult OnGetProductLevel(Guid productLvl)=>new JsonResult(_category.GetProductLvl(productLvl));
        public IActionResult OnGetProductToList(Guid id) => new JsonResult(_invoiceService.ProductToList(id));
        public IActionResult OnGetRemoveFromProductList(Guid id) => new JsonResult(_invoiceService.RemoveFromProductList(id));
    }
}
