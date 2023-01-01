
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopApp.Models;

public class Catalogue
{
  public int Id { get; set; }
  [Required, StringLength(50, MinimumLength = 3)]
  public string Title { get; set; }
  [DisplayFormat(NullDisplayText = "No categories")]
  public ICollection<Category>? Categories { get; set; }
}