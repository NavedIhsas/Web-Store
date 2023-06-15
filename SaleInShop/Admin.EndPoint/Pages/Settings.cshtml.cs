using Application.Interfaces;
using Domain.ShopModels;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SaleInWeb.Pages;

public class SettingsModel : PageModel
{
    private readonly IAuthHelper _authHelper;

    public List<Setting> List;

    public SettingsModel(IAuthHelper authHelper)
    {
        _authHelper = authHelper;
    }

    public void OnGet()
    {
        List = _authHelper.GetSettings();
    }
}