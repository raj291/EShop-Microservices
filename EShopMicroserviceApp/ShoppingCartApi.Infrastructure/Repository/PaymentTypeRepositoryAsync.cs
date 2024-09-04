using ShopingCartApi.Core.Contracts.Repository;
using ShopingCartApi.Core.Entity;
using ShoppingCartApi.Infrastructure.Data;

namespace ShoppingCartApi.Infrastructure.Repository;

public class PaymentTypeRepositoryAsync : BaseRepositoryAsync<PaymentType>, IPaymentTypeRepositoryAsync
{
    public PaymentTypeRepositoryAsync(ShoppingCartDbContext shoppingCartDbContext) : base(shoppingCartDbContext)
    {
    }
}