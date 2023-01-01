using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shopikai.Data;
using ShopApp.Models;

namespace ShopApp.Pages;

public class IndexModel : PageModel
{
  private readonly ShopikaiContext _shopikaiContext;
  private readonly ILogger<IndexModel> _logger;

  [ActivatorUtilitiesConstructor]
  public IndexModel(ILogger<IndexModel> logger, ShopikaiContext shopikaiContext)
  {
    _logger = logger;
    _shopikaiContext = shopikaiContext;
  }

  public int ProductsCount { get; set; }
  public int CategoriesCount { get; set; }
  public int OrdersCount { get; set; }
  public int ReceiptsCount { get; set; }
  public bool IsCatalogueExists { get; set; }

  public void OnGet()
  {
    IQueryable<Product> productQuery = from p in _shopikaiContext.Products
                                       select p;
    IQueryable<Category> categoryQuery = from c in _shopikaiContext.Categories
                                         select c;
    IQueryable<Order> orderQuery = from o in _shopikaiContext.Orders
                                   select o;
    IQueryable<Receipt> receiptQuery = from r in _shopikaiContext.Receipts
                                       select r;
    IsCatalogueExists = _shopikaiContext.Catalogues.Any();

    ProductsCount = productQuery.ToList().Count;
    CategoriesCount = categoryQuery.ToList().Count;
    OrdersCount = orderQuery.ToList().Count;
    ReceiptsCount = receiptQuery.ToList().Count;
  }
}
