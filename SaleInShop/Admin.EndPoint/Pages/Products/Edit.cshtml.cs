using Application.Product;
using Application.Product.Category;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static Application.Product.Category.ProductCategory;

namespace SaleInWeb.Pages.Products
{
    public class EditModel : PageModel
    {
        private readonly IProductService _product;
        private readonly IProductCategory _category;
        public EditProduct Command;
        public List<ProductCategory.SelectOption> Category;
        public List<TaxSelectOptionDto> Tax;
        public List<PropertySelectOptionDto> Properties;
        public CreateProperty Property;
        public List<UnitOfMeasurementDto> Unit;

        public EditModel(IProductService product, IProductCategory category)
        {
            _product = product;
            _category = category;
        }


        public void OnGet(Guid id)
        {
            Command = _product.GetDetailsForEdit(id);
            Category = _category.SelectOptions();
            Tax = _category.TaxSelectOption();
            Properties = _product.PropertySelectOption();
            //HttpContext.Session.Remove("Product-Property");
            Unit = _product.UnitOfMeasurement();
        }
    }
}
