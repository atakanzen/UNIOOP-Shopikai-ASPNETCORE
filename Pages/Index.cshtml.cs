using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesProduct.Data;

namespace ShopApp.Pages;

public class IndexModel : PageModel
{
  private readonly RazorPagesProductContext _context;

  private readonly ILogger<IndexModel> _logger;

  [ActivatorUtilitiesConstructor]
  public IndexModel(ILogger<IndexModel> logger, RazorPagesProductContext context)
  {
    _logger = logger;
    _context = context;
  }

  public int ProductsCount { get; set; }

  public void OnGet()
  {
    IQueryable<string> productQuery = from p in _context.Product
                                      select p.Title;

    ProductsCount = productQuery.ToList().Count;
  }
}
