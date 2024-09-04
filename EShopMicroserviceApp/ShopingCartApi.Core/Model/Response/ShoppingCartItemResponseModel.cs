using System.ComponentModel.DataAnnotations;
using ShopingCartApi.Core.Entity;

namespace ShopingCartApi.Core.Model.Response;

public class ShoppingCartItemResponseModel
{
    public int Id { get; set; }
    [Required]
    public int CartId { get; set; }
    [Required]
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public int QTY { get; set; }
    public decimal Price { get; set; }
    public ShoppingCart ShoppingCart { get; set; }
}