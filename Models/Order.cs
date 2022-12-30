
namespace ShopApp.Models;

public class Order
{
  public int Id { get; set; }
  public ICollection<Product> Products { get; set; }
  public Receipt Receipt { get; set; }
}