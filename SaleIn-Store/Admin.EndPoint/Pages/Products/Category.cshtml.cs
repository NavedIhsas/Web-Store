using System.Collections.Generic;
using Application.Product.Category;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static Application.Product.Category.ProductCategory;

namespace SaleInAdmin.Pages.Products
{
    public class CategoryModel : PageModel
    {
        private readonly IProductCategory _category;

        public CategoryModel(IProductCategory category)
        {
            _category = category;
        }

        public List<ProductLevelDto> List;
        public List<ProductLevelDto> SelectList;
        public int MainCodeCount;
        public int SubCodeCount;
        public void OnGet()
        {
            List = _category.GetLevelList();
            SelectList = _category.GetParentLevelList();
            MainCodeCount = _category.GetMainCodeCount();
            SubCodeCount=_category.GetSubCodeCount();
        }
    }
}
