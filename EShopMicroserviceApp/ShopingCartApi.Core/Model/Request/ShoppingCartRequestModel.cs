using ShopingCartApi.Core.Entity;

namespace ShopingCartApi.Core.Model.Request;

public class ShoppingCartRequestModel
{
    public int CustomerId { get; set; }
    public string CustomerName { get; set; }
    public List<ShoppingCartItem> ShoppingCartItems { get; set; }
}