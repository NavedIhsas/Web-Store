using Application.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SaleInAdmin.Pages.Products
{
    public class IndexModel : PageModel
    {
       private readonly IProductService _productService;

       public IndexModel(IProductService productService)
       {
           _productService = productService;
       }

       public List<ProductDto> Products;
       public void OnGet()
       {
          Products= _productService.GetAll();
       }
    }
}
