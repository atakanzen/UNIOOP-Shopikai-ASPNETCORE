using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShopApp.Models;
using Shopikai.Data;

namespace ShopApp.Pages.Receipts
{
    public class DetailsModel : PageModel
    {
        private readonly Shopikai.Data.ShopikaiContext _context;

        public DetailsModel(Shopikai.Data.ShopikaiContext context)
        {
            _context = context;
        }

      public Receipt Receipt { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Receipts == null)
            {
                return NotFound();
            }

            var receipt = await _context.Receipts.FirstOrDefaultAsync(m => m.Id == id);
            if (receipt == null)
            {
                return NotFound();
            }
            else 
            {
                Receipt = receipt;
            }
            return Page();
        }
    }
}
