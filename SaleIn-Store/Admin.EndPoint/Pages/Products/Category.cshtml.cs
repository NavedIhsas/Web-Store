using Application.Product.Category;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SaleInAdmin.Pages.Products
{
    public class CategoryModel : PageModel
    {
        private readonly IProductCategory _category;

        public CategoryModel(IProductCategory category)
        {
            _category = category;
        }

        public List<ProductCategory.ProductLevelDto> List;
        public List<ProductCategory.ProductLevelDto> SelectList;
        public int MainCodeCount;
        public int SubCodeCount;
        public void OnGet()
        {
            List = _category.GetLevelList();
            SelectList = _category.GetParentLevelList();
            MainCodeCount = _category.GetMainCodeCount();
            SubCodeCount = _category.GetSubCodeCount();
        }


        public void OnPost(ProductCategory.ProductLevelDto command)
        {
            _category.CreatePrdCategory(command);
        }
        public IActionResult OnGetCode(string proLvlId)
        {
            var result = _category.GetPrdLvlCheck(proLvlId);
            return new JsonResult(result);
        }
    }
}
