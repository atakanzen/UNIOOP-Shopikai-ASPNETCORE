using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopApp.Models;

public class Product
{

  [Key]
  public int Id { get; set; }

  [Required, StringLength(100, MinimumLength = 3)]
  public string Title { get; set; }

  [ForeignKey("Category")]
  public int CategoryId { get; set; }
  public Category? Category { get; set; }


  // Types decimal, float, int, DateTime are required by default.
  [Display(Name = "Release Date"), DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
  public DateTime ReleaseDate { get; set; }

  [Column(TypeName = "decimal(18, 2)"), DataType(DataType.Currency), Range(1, 999999)]
  public decimal Price { get; set; }

  [Range(1, 999999)]
  public int Stock { get; set; }

  [Required, Display(Name = "Has Discount")]
  public bool HasDiscount { get; set; } = false;
}