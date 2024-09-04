using OrderApi.Core.Contracts.Repository;
using OrderApi.Core.Entity;
using OrderApi.Infrastructure.Data;

namespace OrderApi.Infrastructure.Repository;

public class OrderRepositoryAsync : BaseRepositoryAsync<Order> , IOrderRepositoryAsync
{
    public OrderRepositoryAsync(OrderDbContext orderDbContext) : base(orderDbContext)
    {
    }
}