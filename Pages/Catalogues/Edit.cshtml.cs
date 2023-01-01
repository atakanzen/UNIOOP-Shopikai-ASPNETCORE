using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShopApp.Models;
using Shopikai.Data;

namespace ShopApp.Pages.Catalogues
{
    public class EditModel : PageModel
    {
        private readonly Shopikai.Data.ShopikaiContext _context;

        public EditModel(Shopikai.Data.ShopikaiContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Catalogue Catalogue { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Catalogues == null)
            {
                return NotFound();
            }

            var catalogue =  await _context.Catalogues.FirstOrDefaultAsync(m => m.Id == id);
            if (catalogue == null)
            {
                return NotFound();
            }
            Catalogue = catalogue;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Catalogue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatalogueExists(Catalogue.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CatalogueExists(int id)
        {
          return (_context.Catalogues?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
