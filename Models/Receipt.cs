namespace ShopApp.Models;

public class Receipt
{
  public int Id { get; set; }
  public int OrderId { get; set; }
  public Order Order { get; set; }
}