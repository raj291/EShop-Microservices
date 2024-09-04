using ShopingCartApi.Core.Entity;

namespace ShopingCartApi.Core.Model.Response;

public class ShoppingCartResponseModel
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public string CustomerName { get; set; }
    public List<ShoppingCartItem> ShoppingCartItems { get; set; }
}