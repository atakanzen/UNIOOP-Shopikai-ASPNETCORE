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
    public class DeleteModel : PageModel
    {
        private readonly Shopikai.Data.ShopikaiContext _context;

        public DeleteModel(Shopikai.Data.ShopikaiContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Receipts == null)
            {
                return NotFound();
            }
            var receipt = await _context.Receipts.FindAsync(id);

            if (receipt != null)
            {
                Receipt = receipt;
                _context.Receipts.Remove(Receipt);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
