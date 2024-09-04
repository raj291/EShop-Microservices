using System.ComponentModel.DataAnnotations.Schema;

namespace OrderApi.Core.Entity;

public class OrderDetails
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int? ProductId { get; set; }
    public string? ProductName { get; set; }
    public int QTY { get; set; }
    [Column(TypeName = "decimal(5,2)")]
    public decimal Price { get; set; }
    public int? Discount { get; set; }

    public Order Order { get; set; }
}