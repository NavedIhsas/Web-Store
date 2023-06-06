using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SaleInWeb.Pages
{
    public class SettingsModel : PageModel
    {
        private readonly IAuthHelper _authHelper;

        public SettingsModel(IAuthHelper authHelper)
        {
            _authHelper = authHelper;
        }

        public List<Domain.ShopModels.Setting> List;
        public void OnGet()
        {
           List= _authHelper.GetSettings();
        }
    }
}
