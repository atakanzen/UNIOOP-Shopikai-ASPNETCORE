using Shopikai.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShopApp.Models;
using System.Linq;

namespace ShopApp.Pages.Categories
{
  public class CategoryPageModel : PageModel
  {
    public SelectList CatalogueTitleSL { get; set; }

    public void PopulateCatalogueDropdownList(ShopikaiContext _context, object selectedCatalogue = null)
    {
      var cataloguesQuery = from c in _context.Catalogues
                            orderby c.Title
                            select c;

      CatalogueTitleSL = new SelectList(cataloguesQuery.AsNoTracking(), nameof(Catalogue.Id), nameof(Catalogue.Title), selectedCatalogue);
    }

  }
}

