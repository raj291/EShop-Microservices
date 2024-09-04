using ShopingCartApi.Core.Model.Request;
using ShopingCartApi.Core.Model.Response;

namespace ShopingCartApi.Core.Contracts.Service;

public interface IPaymentMethodServiceAsync
{
    Task<int> InsertPaymentMethodAsync(PaymentMethodRequestModel model);
    Task<int> DeletePaymentMethodAsync(int id);
    Task<int> UpdatePaymentMethodAsync(PaymentMethodRequestModel model, int id);
    Task<PaymentMethodResponseModel> GetPaymentMethodByIdAsync(int id);
    Task<IEnumerable<PaymentMethodResponseModel>> GetAllPaymentMethodAsync();
}