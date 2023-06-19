using Application.Common;
using Application.Product;
using Application.Product.ProductDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace SaleInWeb.Pages.Products;

public class IndexModel : PageModel
{
    private readonly IProductService _productService;
    public ProductDetails Details;

    public List<ProductDto> Products;

    public IndexModel(IProductService productService)
    {
        _productService = productService;
    }

    public void OnGet()
    {
        Products = _productService.GetAll();
    }

    public IActionResult OnGetData(JqueryDatatableParam param)
    {
        var result = _productService.GetAllProduct(param);
        return result;
    }

    public IActionResult OnGetDetails(Guid id)
    {
        var details = _productService.GetDetails(id);
        details.Properties = _productService.GetProductProperty(id);
        details.Pictures = _productService.GetProductPictures(id);
        return new JsonResult(details);
    }

    public IActionResult OnGetPictures(Guid id)
    {
        return new JsonResult(_productService.GetProductPictures(id));
    }

    public IActionResult OnGetRemove(Guid id)
    {
        return new JsonResult(_productService.Remove(id));
    }
}