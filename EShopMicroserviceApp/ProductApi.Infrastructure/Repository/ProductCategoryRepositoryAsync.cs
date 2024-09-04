using ProductApi.Core.Contracts.Repository;
using ProductApi.Core.Entity;
using ProductApi.Infrastructure.Data;

namespace ProductApi.Infrastructure.Repository;

public class ProductCategoryRepositoryAsync : BaseRepositoryAsync<ProductCategory>, IProductCategoryRepositoryAsync
{
    public ProductCategoryRepositoryAsync(ProductDbcontext productDbcontext) : base(productDbcontext)
    {
        
    }
}