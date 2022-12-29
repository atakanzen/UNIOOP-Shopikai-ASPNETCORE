using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopApp.Models;

public class Product
{
  public int Id { get; set; }

  [StringLength(100, MinimumLength = 3)]
  [Required]
  public string Title { get; set; }

  [Required]
  public string Category { get; set; }


  // Types decimal, float, int, DateTime are required by default.
  [Display(Name = "Release Date")]
  [DataType(DataType.Date)]
  [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
  public DateTime ReleaseDate { get; set; }

  [Column(TypeName = "decimal(18, 2)")]
  [DataType(DataType.Currency)]
  [Range(1, 999999)]
  public decimal Price { get; set; }

  [Range(1, 999999)]
  public int Stock { get; set; }

  [Required]
  [Display(Name = "Has Discount")]
  public bool HasDiscount { get; set; } = false;

}