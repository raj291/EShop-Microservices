using AutoMapper;
using ShopingCartApi.Core.Contracts.Repository;
using ShopingCartApi.Core.Contracts.Service;
using ShopingCartApi.Core.Entity;
using ShopingCartApi.Core.Model.Request;
using ShopingCartApi.Core.Model.Response;

namespace ShoppingCartApi.Infrastructure.Service;

public class PaymentMethodServiceAsync : IPaymentMethodServiceAsync
{
    private readonly IPaymentMethodRepositoryAsync _paymentMethodRepositoryAsync;
    private readonly IMapper _mapper;

    public PaymentMethodServiceAsync(IPaymentMethodRepositoryAsync paymentMethodRepositoryAsync, IMapper mapper)
    {
        _paymentMethodRepositoryAsync = paymentMethodRepositoryAsync;
        _mapper = mapper;
    }
    public async Task<int> InsertPaymentMethodAsync(PaymentMethodRequestModel model)
    {
        PaymentMethod pm = _mapper.Map<PaymentMethod>(model);
        return await _paymentMethodRepositoryAsync.InsertAsync(pm);
    }

    public async Task<int> DeletePaymentMethodAsync(int id)
    {
        return await _paymentMethodRepositoryAsync.DeleteAsync(id);
    }

    public async Task<int> UpdatePaymentMethodAsync(PaymentMethodRequestModel model, int id)
    {
        var result = await _paymentMethodRepositoryAsync.GetbyIdAsync(id);
        if (result != null)
        {
            _mapper.Map(model, result);
            return await _paymentMethodRepositoryAsync.UpdateAsync(result);
        }

        return 0;
    }

    public async Task<PaymentMethodResponseModel> GetPaymentMethodByIdAsync(int id)
    {
        var result = await _paymentMethodRepositoryAsync.GetbyIdAsync(id);
        return _mapper.Map<PaymentMethodResponseModel>(result);
    }

    public async Task<IEnumerable<PaymentMethodResponseModel>> GetAllPaymentMethodAsync()
    {
        return _mapper.Map<IEnumerable<PaymentMethodResponseModel>>(await _paymentMethodRepositoryAsync.GetAllAsync());
    }
}