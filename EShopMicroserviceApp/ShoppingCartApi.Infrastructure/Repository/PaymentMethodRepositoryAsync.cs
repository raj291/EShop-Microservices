using ShopingCartApi.Core.Contracts.Repository;
using ShopingCartApi.Core.Contracts.Service;
using ShopingCartApi.Core.Entity;
using ShoppingCartApi.Infrastructure.Data;

namespace ShoppingCartApi.Infrastructure.Repository;

public class PaymentMethodRepositoryAsync : BaseRepositoryAsync<PaymentMethod> , IPaymentMethodRepositoryAsync
{
    public PaymentMethodRepositoryAsync(ShoppingCartDbContext shoppingCartDbContext) : base(shoppingCartDbContext)
    {
    }

   
}