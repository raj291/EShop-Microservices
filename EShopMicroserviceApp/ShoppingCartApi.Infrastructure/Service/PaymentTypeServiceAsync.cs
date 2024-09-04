using AutoMapper;
using ShopingCartApi.Core.Contracts.Repository;
using ShopingCartApi.Core.Contracts.Service;
using ShopingCartApi.Core.Entity;
using ShopingCartApi.Core.Model.Request;
using ShopingCartApi.Core.Model.Response;

namespace ShoppingCartApi.Infrastructure.Service;

public class PaymentTypeServiceAsync : IPaymentTypeServiceAsync
{
    private readonly IPaymentTypeRepositoryAsync _paymentTypeRepositoryAsync;
    private readonly IMapper _mapper;

    public PaymentTypeServiceAsync(IPaymentTypeRepositoryAsync paymentTypeRepositoryAsync, IMapper mapper)
    {
        _paymentTypeRepositoryAsync = paymentTypeRepositoryAsync;
        _mapper = mapper;
    }
    public async Task<int> InsertPaymentTypeAsync(PaymentTypeRequestModel model)
    {
        PaymentType pt = _mapper.Map<PaymentType>(model);
        return await _paymentTypeRepositoryAsync.InsertAsync(pt);
    }

    public Task<int> DeletePaymentTypeAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<int> UpdatePaymentTypeAsync(PaymentTypeRequestModel model, int id)
    {
        throw new NotImplementedException();
    }

    public Task<PaymentTypeResponseModel> GetPaymentTypeByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<PaymentTypeResponseModel>> GetAllPaymentTypeAsync()
    {
        return _mapper.Map<IEnumerable<PaymentTypeResponseModel>>(await _paymentTypeRepositoryAsync.GetAllAsync());
    }
}