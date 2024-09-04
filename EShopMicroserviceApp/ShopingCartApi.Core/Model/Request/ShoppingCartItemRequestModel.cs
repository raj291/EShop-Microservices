using System.ComponentModel.DataAnnotations;
using ShopingCartApi.Core.Entity;

namespace ShopingCartApi.Core.Model.Request;

public class ShoppingCartItemRequestModel
{
    [Required]
    public int CartId { get; set; }
    [Required]
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public int QTY { get; set; }
    public decimal Price { get; set; }
    public ShoppingCart ShoppingCart { get; set; }
}