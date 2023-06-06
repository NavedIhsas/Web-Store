using Application.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SaleInWeb.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly IProductService _productService;

        public IndexModel(IProductService productService)
        {
            _productService = productService;
        }

        public List<ProductDto> Products;
        public ProductDetails Details;
        public void OnGet()
        {
            Products = _productService.GetAll();
            
        }

        public IActionResult OnGetDetails(Guid id)
        {
            var details = _productService.GetDetails(id);
            details.Properties = _productService.GetProductProperty(id);
            return new JsonResult(details);
        }
    }
}
