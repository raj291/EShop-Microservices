using CustomerApi.Core.Model.Request;
using CustomerApi.Core.Model.Response;

namespace CustomerApi.Core.Contracts.Services;

public interface ICustomerServiceAsync
{
    Task<int> InsertCustomerAsync(CustomerRequestModel model);
    Task<CustomerResponseModel> GetCustomerByIdAsync(int id);
    Task<int> UpdateCustomerAsync(CustomerRequestModel model);
    Task<IEnumerable<CustomerResponseModel>> GetAllCustomerAsync();
}