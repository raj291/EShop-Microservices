using AutoMapper;
using OrderApi.Core.Contracts.Repository;
using OrderApi.Core.Contracts.Services;
using OrderApi.Core.Entity;
using OrderApi.Core.Models.Request;
using OrderApi.Core.Models.Response;

namespace OrderApi.Infrastructure.Services;

public class OrderServiceAsync : IOrderServiceAsync
{
    private readonly IOrderRepositoryAsync _orderRepositoryAsync;
    private readonly IMapper _mapper;

    public OrderServiceAsync(IOrderRepositoryAsync orderRepositoryAsync, IMapper mapper)
    {
        _orderRepositoryAsync = orderRepositoryAsync;
        _mapper = mapper;
    }
    public async Task<int> InsertOrderAsync(OrderRequestModel model)
    {
        Order o = _mapper.Map<Order>(model);
        return await _orderRepositoryAsync.InsertAsync(o);
    }

    public async Task<int> DeleteOrderAsync(int id)
    {
         return await _orderRepositoryAsync.DeleteAysnc(id);
    }

    public async Task<OrderResponseModel> GetOrderByIdAsync(int id)
    {
        var result = await _orderRepositoryAsync.GetByIdAsync(id);
        return _mapper.Map<OrderResponseModel>(result);
    }

    public async Task<int> UpdateOrderAsync(OrderRequestModel model)
    {
        Order O = _mapper.Map<Order>(model);
        return await _orderRepositoryAsync.UpdateAsync(O);
    }

    public async Task<IEnumerable<OrderResponseModel>> GetAllOrdersAsync()
    {
        return _mapper.Map<IEnumerable<OrderResponseModel>>(await _orderRepositoryAsync.GetAllAsync());
    }
}