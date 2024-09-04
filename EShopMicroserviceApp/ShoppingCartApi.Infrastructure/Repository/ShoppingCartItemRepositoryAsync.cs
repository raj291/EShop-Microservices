using ShopingCartApi.Core.Contracts.Repository;
using ShopingCartApi.Core.Entity;
using ShoppingCartApi.Infrastructure.Data;

namespace ShoppingCartApi.Infrastructure.Repository;

public class ShoppingCartItemRepositoryAsync : BaseRepositoryAsync<ShoppingCartItem>, IShoppingCartItemRepositoryAsync
{
    public ShoppingCartItemRepositoryAsync(ShoppingCartDbContext shoppingCartDbContext) : base(shoppingCartDbContext)
    {
    }
}