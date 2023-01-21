using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShopApp.Models;
using Shopikai.Data;

namespace ShopApp.Pages.Orders
{
  public class IndexModel : PageModel
  {
    private readonly Shopikai.Data.ShopikaiContext _context;

    public IndexModel(Shopikai.Data.ShopikaiContext context)
    {
      _context = context;
    }

    public IList<Order> Orders { get; set; } = default!;

    public async Task OnGetAsync()
    {
      if (_context.Orders != null)
      {
        Orders = await _context.Orders.ToListAsync();
      }
    }
  }
}
