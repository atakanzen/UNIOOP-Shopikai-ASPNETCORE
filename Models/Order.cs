using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ShopApp.Models;

public enum ShippingMethod
{
  DirectDelivery,
  InPost
}

public enum PaymentMethod
{
  Card,
  Cash,
  PayPal
}


public class Order
{
  [Key, Display(Name = "Order ID")]
  public int Id { get; set; }

  [DataType(DataType.PostalCode), Required, Display(Name = "Postal Code")]
  public string ShipmentPostalCode { get; set; }

  [Required, StringLength(50, MinimumLength = 3), Display(Name = "Address Label")]
  public string ShipmentAddressLabel { get; set; }

  [Required, StringLength(100, MinimumLength = 20)]
  public string ShipmentAddress { get; set; }

  public string ShipmentTrackingID { get; set; }

  [Required, Display(Name = "Shipping Method")]
  public ShippingMethod ShippingMethod { get; set; }

  [Required, DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
  public DateTime ShippingDate { get; set; }

  [Required, Display(Name = "Payment Method")]
  public PaymentMethod PaymentMethod { get; set; }

  [DataType(DataType.Currency)]
  public decimal Total { get; set; }

  private int _numberOfProducts;
  [Display(Name = "Number of Products")]
  public int NumberOfProducts { get; set; }
  public ICollection<Product>? Products { get; set; }
  public Receipt? Receipt { get; set; }
}