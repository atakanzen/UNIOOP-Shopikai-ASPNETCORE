using System.ComponentModel.DataAnnotations;

namespace ShopApp.Models;

public class Category
{
  public int Id { get; set; }
  [Display(Name = "Catalogue")]
  public int CatalogueId { get; set; }
  [Required, StringLength(150, MinimumLength = 3)]
  public string Title { get; set; }
  public Catalogue Catalogue { get; set; }
  public ICollection<Product>? Products { get; set; }

}