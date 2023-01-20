using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopApp.Models;

public class Category
{
  [Key]
  public int Id { get; set; }

  [Required, StringLength(150, MinimumLength = 3)]
  public string Title { get; set; }

  [ForeignKey("Catalogue")]
  [Display(Name = "Catalogue")]
  public int CatalogueId { get; set; }
  public Catalogue? Catalogue { get; set; }

  public ICollection<Product>? Products { get; set; }

}