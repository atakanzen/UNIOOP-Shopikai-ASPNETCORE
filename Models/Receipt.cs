using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopApp.Models;

public class Receipt
{
  [Key]
  public int Id { get; set; }

  [ForeignKey("Order")]
  public int OrderId { get; set; }
  public Order Order { get; set; }
}