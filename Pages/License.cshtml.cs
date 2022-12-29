using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ShopApp.Pages;

public class LicenseModel : PageModel
{
  private readonly ILogger<LicenseModel> _logger;

  public LicenseModel(ILogger<LicenseModel> logger)
  {
    _logger = logger;
  }

  public void OnGet()
  {
  }
}

