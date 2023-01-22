using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopApp.Models;
using System.ComponentModel.DataAnnotations;
using Shopikai.Data;

namespace ShopApp.Pages.Orders
{
  public class CreateModel : OrderPageModel
  {
    private readonly Shopikai.Data.ShopikaiContext _context;

    public CreateModel(Shopikai.Data.ShopikaiContext context, ILogger<OrderPageModel> logger)
    {
      _context = context;
    }

    public IActionResult OnGet()
    {
      PopulateProductsSL(_context);
      return Page();
    }

    [BindProperty]
    public Order Order { get; set; } = default!;

    [BindProperty]
    public int[]? SelectedProductIds { get; set; }

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
      if (SelectedProductIds == null)
      {
        PopulateProductsSL(_context);
        return Page();
      }

      var newOrder = new Order();
      newOrder.Products = new List<Product>();

      foreach (int selectedProductID in SelectedProductIds)
      {
        var product = await _context.Products.FindAsync(selectedProductID);
        if (product != null)
        {
          newOrder.Products.Add(product);
          newOrder.Total += product.Price;
        }
      }

      newOrder.NumberOfProducts = newOrder.Products.Count;
      Random rnd = new Random();
      newOrder.ShipmentTrackingID = rnd.Next().ToString("X");

      if (await TryUpdateModelAsync<Order>(
           newOrder,
           "Order",
           o => o.ShipmentPostalCode,
           o => o.ShipmentAddressLabel,
           o => o.ShipmentAddress,
           o => o.ShippingMethod,
           o => o.ShippingDate,
           o => o.PaymentMethod,
           o => o.Total,
           o => o.NumberOfProducts,
           o => o.Products))
      {
        _context.Orders.Add(newOrder);
        await _context.SaveChangesAsync();
        return RedirectToPage("./Index");
      }

      PopulateProductsSL(_context);
      return Page();
    }
  }
}
