using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesProduct.Data;

namespace ShopApp.Pages;

public class IndexModel : PageModel
{
  private readonly RazorPagesProductContext _productContext;
  private readonly RazorPagesCategoryContext _categoryContext;
  private readonly RazorPagesOrderContext _orderContext;
  private readonly RazorPagesReceiptContext _receiptContext;

  private readonly ILogger<IndexModel> _logger;

  [ActivatorUtilitiesConstructor]
  public IndexModel(ILogger<IndexModel> logger, RazorPagesProductContext productContext, RazorPagesCategoryContext categoryContext, RazorPagesOrderContext orderContext, RazorPagesReceiptContext receiptContext)
  {
    _logger = logger;
    _productContext = productContext;
    _categoryContext = categoryContext;
    _orderContext = orderContext;
    _receiptContext = receiptContext;
  }

  public int ProductsCount { get; set; }
  public int CategoriesCount { get; set; }
  public int OrdersCount { get; set; }
  public int ReceiptsCount { get; set; }

  public void OnGet()
  {
    IQueryable<string> productQuery = from p in _productContext.Product
                                      select p.Title;
    IQueryable<string> categoryQuery = from c in _categoryContext.Category
                                       select c.Title;
    IQueryable<int> orderQuery = from o in _orderContext.Order
                                 select o.Id;
    IQueryable<int> receiptQuery = from r in _receiptContext.Receipt
                                   select r.Id;

    ProductsCount = productQuery.ToList().Count;
    CategoriesCount = categoryQuery.ToList().Count;
    OrdersCount = orderQuery.ToList().Count;
    ReceiptsCount = receiptQuery.ToList().Count;
  }
}
