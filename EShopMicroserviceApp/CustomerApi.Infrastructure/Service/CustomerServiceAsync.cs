using AutoMapper;
using CustomerApi.Core.Contracts.Repository;
using CustomerApi.Core.Contracts.Services;
using CustomerApi.Core.Entity;
using CustomerApi.Core.Model.Request;
using CustomerApi.Core.Model.Response;

namespace CustomerApi.Infrastructure.Service;

public class CustomerServiceAsync : ICustomerServiceAsync
{
    private readonly ICustomerRepositoryAsync _customerRepositoryAsync;
    private readonly IMapper _mapper;

    public CustomerServiceAsync(ICustomerRepositoryAsync customerRepositoryAsync, IMapper mapper)
    {
        _customerRepositoryAsync = customerRepositoryAsync;
        _mapper = mapper;
    }


    public async Task<int> InsertCustomerAsync(CustomerRequestModel model)
    {
        Customer c = _mapper.Map<Customer>(model);
        return await _customerRepositoryAsync.InsertAsync(c);
    }

    public Task<CustomerResponseModel> GetCustomerByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<int> UpdateCustomerAsync(CustomerRequestModel model)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<CustomerResponseModel>> GetAllCustomerAsync()
    {
        return _mapper.Map<IEnumerable<CustomerResponseModel>>(await _customerRepositoryAsync.GetAllAsync());
    }
}