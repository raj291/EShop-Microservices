using CustomerApi.Core.Contracts.Repository;
using CustomerApi.Core.Entity;
using CustomerApi.Infrastructure.Data;

namespace CustomerApi.Infrastructure.Repository;

public class CustomerRepositoryAsync : BaseRepositoryAsync<Customer>, ICustomerRepositoryAsync
{
    public CustomerRepositoryAsync(CustomerDbContext customerDbContext) : base(customerDbContext)
    {
    }
}