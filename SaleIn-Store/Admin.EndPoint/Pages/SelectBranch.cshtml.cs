using Application.Interfaces;
using Domain.SaleInModels;
using infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SaleInAdmin.Pages
{
    public class SelectBranchModel : PageModel
    {
        private readonly IAuthHelper _authHelper;

        public SelectBranchModel(IAuthHelper authHelper)
        {
            _authHelper = authHelper;
        }

        public List<BusinessUnit> Branch;

        public void OnGet()
        {
           // Branch = _authHelper.SelectBranch();
        }

        public void OnPost(string branchId)
        {
            var session = HttpContext.Session.GetJson<string>("Branch") ?? branchId;
            HttpContext.Session.SetJson("Branch",session);
            OnGet();
        }
    }
}



