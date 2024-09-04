using System.ComponentModel.DataAnnotations.Schema;

namespace OrderApi.Core.Models.Request;

public class OrderDetailsRequestModel
{
    public int OrderId { get; set; }
    public int? ProductId { get; set; }
    public string? ProductName { get; set; }
    public int QTY { get; set; }
    [Column(TypeName = "decimal(5,2)")]
    public decimal Price { get; set; }
    public int? Discount { get; set; }

   
}