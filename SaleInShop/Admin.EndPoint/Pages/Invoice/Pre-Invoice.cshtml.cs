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

        public  IActionResult OnPost()
        {
            return new JsonResult(_invoiceService.Create());
        }
        public IActionResult OnGetData(JqueryDatatableParam param)
        {
            return _product.GetAllProductForInvoice(param);
        }

        public IActionResult OnGetInvoiceList()
        {
            return new JsonResult(_invoiceService.GetInvoiceList());
        }

        public IActionResult OnGetProductLevel(Guid productLvl,Guid accClbType)=>new JsonResult(_category.GetProductLvl(productLvl, accClbType));
        public IActionResult OnGetProductToList(Guid id) => new JsonResult(_invoiceService.ProductToList(id));
        public IActionResult OnGetRemoveFromProductList(Guid id) => new JsonResult(_invoiceService.RemoveFromProductList(id));
    }
}
