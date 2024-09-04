using ShopingCartApi.Core.Entity;
using ShopingCartApi.Core.Model.Request;
using ShopingCartApi.Core.Model.Response;

namespace ShopingCartApi.Core.Contracts.Service;

public interface IPaymentTypeServiceAsync
{
    Task<int> InsertPaymentTypeAsync(PaymentTypeRequestModel model);
    Task<int> DeletePaymentTypeAsync(int id);
    Task<int> UpdatePaymentTypeAsync(PaymentTypeRequestModel model, int id);
    Task<PaymentTypeResponseModel> GetPaymentTypeByIdAsync(int id);
    Task<IEnumerable<PaymentTypeResponseModel>> GetAllPaymentTypeAsync();
}