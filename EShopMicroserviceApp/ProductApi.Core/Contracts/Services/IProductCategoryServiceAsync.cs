using ProductApi.Core.Models.Request;
using ProductApi.Core.Models.Response;

namespace ProductApi.Core.Contracts.Services;

public interface IProductCategoryServiceAsync
{
    Task<int> InsertProductCategoryAsync(ProductCategoryRequestModel model);
    Task<IEnumerable<ProductCategoryResponseModel>> GetAllProductCategoryAsync();
}