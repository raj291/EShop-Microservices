using System.ComponentModel.DataAnnotations.Schema;

namespace OrderApi.Core.Models.Response;

public class OrderResponseModel
{
    public int Id { get; set; }
    public DateTime? OrderDate { get; set; }
    public int CustomerId { get; set; }
    public string CustomerName { get; set; }
    public int PaymentMethodId { get; set; }
    public string PaymentName { get; set; }
    public string? ShippingAddress { get; set; }
    public string? ShippingMethod { get; set; }
    [Column(TypeName = "decimal(5,2)")]
    public decimal BillAmount { get; set; }
    public string? OrderStatus { get; set; }

}