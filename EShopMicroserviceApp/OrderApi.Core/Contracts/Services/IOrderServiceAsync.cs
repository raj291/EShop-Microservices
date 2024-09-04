using OrderApi.Core.Models.Request;
using OrderApi.Core.Models.Response;

namespace OrderApi.Core.Contracts.Services;

public interface IOrderServiceAsync
{
    Task<int> InsertOrderAsync(OrderRequestModel model);
    Task<int> DeleteOrderAsync(int id);
    Task<OrderResponseModel> GetOrderByIdAsync(int id);
    Task<int> UpdateOrderAsync(OrderRequestModel model);
    Task<IEnumerable<OrderResponseModel>> GetAllOrdersAsync();
}