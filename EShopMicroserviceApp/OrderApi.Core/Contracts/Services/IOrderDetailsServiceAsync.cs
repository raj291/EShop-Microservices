using OrderApi.Core.Models.Request;
using OrderApi.Core.Models.Response;

namespace OrderApi.Core.Contracts.Services;

public interface IOrderDetailsServiceAsync
{
    Task<int> InsertOrderDetailsAsync(OrderDetailsRequestModel model);
    Task<int> DeleteOrderDetailsAsync(int id);
    Task<int> UpdateOrderDetailsAsync(OrderDetailsRequestModel model , int id);
    Task<OrderDetailsResponseModel> GetOrderDetailByIdAsync(int id);
    Task<IEnumerable<OrderDetailsResponseModel>> GetAllOrderDetailsAsync();
}