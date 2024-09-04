using ShopingCartApi.Core.Contracts.Repository;
using ShopingCartApi.Core.Entity;
using ShoppingCartApi.Infrastructure.Data;

namespace ShoppingCartApi.Infrastructure.Repository;

public class ShoppingCartRepositoryAsync : BaseRepositoryAsync<ShoppingCart> , IShoppingCartRepositoryAsync
{
    public ShoppingCartRepositoryAsync(ShoppingCartDbContext shoppingCartDbContext) : base(shoppingCartDbContext)
    {
    }
}