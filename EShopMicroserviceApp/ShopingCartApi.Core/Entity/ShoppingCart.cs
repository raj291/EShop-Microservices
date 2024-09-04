namespace ShopingCartApi.Core.Entity;

public class ShoppingCart
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public string CustomerName { get; set; }
    public List<ShoppingCartItem> ShoppingCartItems { get; set; }
}