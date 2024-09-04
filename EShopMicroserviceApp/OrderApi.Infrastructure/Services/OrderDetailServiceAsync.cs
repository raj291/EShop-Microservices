using AutoMapper;
using OrderApi.Core.Contracts.Repository;
using OrderApi.Core.Contracts.Services;
using OrderApi.Core.Entity;
using OrderApi.Core.Models.Request;
using OrderApi.Core.Models.Response;

namespace OrderApi.Infrastructure.Services;

public class OrderDetailServiceAsync : IOrderDetailsServiceAsync
{
    private readonly IOrderDetailsRepositoryAsync _orderDetailsRepositoryAsync;
    private readonly IMapper _mapper;

    public OrderDetailServiceAsync(IOrderDetailsRepositoryAsync orderDetailsRepositoryAsync, IMapper mapper)
    {
        _orderDetailsRepositoryAsync = orderDetailsRepositoryAsync;
        _mapper = mapper;
    }
    public async Task<int> InsertOrderDetailsAsync(OrderDetailsRequestModel model)
    {
        OrderDetails od = _mapper.Map<OrderDetails>(model);
        return await _orderDetailsRepositoryAsync.InsertAsync(od);
    }

    public async Task<int> DeleteOrderDetailsAsync(int id)
    {
        return await _orderDetailsRepositoryAsync.DeleteAysnc(id);
    }

    public async Task<int> UpdateOrderDetailsAsync(OrderDetailsRequestModel model , int id)
    {
        var result = _orderDetailsRepositoryAsync.GetByIdAsync(id);
        if (result != null)
        {
            return await _orderDetailsRepositoryAsync.UpdateAsync(_mapper.Map<OrderDetails>(result));
        }

        return 0;

    }

    public async Task<OrderDetailsResponseModel> GetOrderDetailByIdAsync(int id)
    {
        var result = await _orderDetailsRepositoryAsync.GetByIdAsync(id);
        return _mapper.Map<OrderDetailsResponseModel>(result);
    }

    public async Task<IEnumerable<OrderDetailsResponseModel>> GetAllOrderDetailsAsync()
    {
        return _mapper.Map<IEnumerable<OrderDetailsResponseModel>>(await _orderDetailsRepositoryAsync.GetAllAsync());
    }
}