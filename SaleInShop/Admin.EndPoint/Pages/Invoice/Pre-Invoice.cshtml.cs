using Application.Invoice;
using Application.Product.Category;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SaleInWeb.Pages.Invoice
{
    public class PreInvoiceModel : PageModel
    {
        private readonly IProductCategory _category;
        private readonly IInvoiceService _invoiceService;
        public PreInvoiceModel(IProductCategory category, IInvoiceService invoiceService)
        {
            _category = category;
            _invoiceService = invoiceService;
        }

        public List<ProductCategory.ProductLevelDto> Categories;
        public void OnGet()
        {
            Categories = _category.GetLevelList();
        }

        public IActionResult OnGetProductLevel(Guid productLvl)=>new JsonResult(_category.GetProductLvl(productLvl));
        public IActionResult OnGetProductToList(Guid id) => new JsonResult(_invoiceService.ProductToList(id));
        public IActionResult OnGetRemoveFromProductList(Guid id) => new JsonResult(_invoiceService.RemoveFromProductList(id));
    }
}
