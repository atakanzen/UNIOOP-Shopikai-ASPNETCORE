using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ShopApp.Models;

public class Order
{
  [Key]
  public int Id { get; set; }

  public ICollection<Product> Products { get; set; }
  public Receipt Receipt { get; set; }
}