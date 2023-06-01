using Application.Common;
using Application.Product;
using Application.Product.Category;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static Application.Product.Category.ProductCategory;

namespace SaleInWeb.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly IProductCategory _category;
        private readonly IProductService _product;

        public CreateModel(IProductCategory category, IProductService product)
        {
            _category = category;
            _product = product;
        }

        public List<ProductCategory.SelectOption> Category;
        public List<TaxSelectOptionDto> Tax;
        public CreateProduct Command;
        public List<PropertySelectOptionDto> Properties;
        public CreateProperty Property;
        public void OnGet()
        {
            Category = _category.SelectOptions();
            Tax = _category.TaxSelectOption();
            Properties = _product.PropertySelectOption();
        }

        public void OnPost(CreateProduct command)
        {

        }

        public IActionResult OnGetProperty(CreateProperty property)
        {
            var getProperty = HttpContext.Session.GetJson<List<PropertySelectOptionDto>>("Product-Property")??new List<PropertySelectOptionDto>();
            if (getProperty.Any(x => x.Id == property.Id))
                return new JsonResult("Duplicate");
            getProperty.Add(new PropertySelectOptionDto()
            {
                Name = property.Name,
                Id = property.Id,
                Value = property.Value,
            });
            HttpContext.Session.SetJson("Product-Property", getProperty);
            return new JsonResult(getProperty);
        }

        public IActionResult OnGetRemoveProperty(Guid id)
        {
            var getProperty = HttpContext.Session.GetJson<List<PropertySelectOptionDto>>("Product-Property") ?? new List<PropertySelectOptionDto>();
            var get = getProperty.SingleOrDefault(x => x.Id == id);
            if (get != null)
                getProperty.Remove(get);
            
            HttpContext.Session.SetJson("Product-Property", getProperty);
            return new JsonResult(getProperty);
        }
    }
}
