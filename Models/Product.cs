using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopApp.Models;

public class Product
{
  public int Id { get; set; }
  public string? Title { get; set; }
  public string? Category { get; set; }
  [Display(Name = "Release Date")]
  [DataType(DataType.Date)]
  public DateTime ReleasedDate { get; set; }
  [Column(TypeName = "decimal(18, 2)")]
  public decimal Price { get; set; }
  public int Stock { get; set; }
}