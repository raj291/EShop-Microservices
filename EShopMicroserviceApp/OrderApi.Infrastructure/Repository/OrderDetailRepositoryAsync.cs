using OrderApi.Core.Contracts.Repository;
using OrderApi.Core.Entity;
using OrderApi.Infrastructure.Data;

namespace OrderApi.Infrastructure.Repository;

public class OrderDetailRepositoryAsync : BaseRepositoryAsync<OrderDetails> , IOrderDetailsRepositoryAsync
{
    public OrderDetailRepositoryAsync(OrderDbContext orderDbContext) : base(orderDbContext)
    {
    }
}