using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesProduct.Data;
using ShopApp.Models;

namespace ShopApp.Pages.Receipts
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesProduct.Data.RazorPagesReceiptContext _context;

        public DetailsModel(RazorPagesProduct.Data.RazorPagesReceiptContext context)
        {
            _context = context;
        }

      public Receipt Receipt { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Receipt == null)
            {
                return NotFound();
            }

            var receipt = await _context.Receipt.FirstOrDefaultAsync(m => m.Id == id);
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
