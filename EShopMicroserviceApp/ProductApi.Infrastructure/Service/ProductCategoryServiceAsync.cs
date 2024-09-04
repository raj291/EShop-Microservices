using AutoMapper;
using ProductApi.Core.Contracts.Repository;
using ProductApi.Core.Contracts.Services;
using ProductApi.Core.Entity;
using ProductApi.Core.Models.Request;
using ProductApi.Core.Models.Response;

namespace ProductApi.Infrastructure.Service;

public class ProductCategoryServiceAsync : IProductCategoryServiceAsync
{
    private readonly IProductCategoryRepositoryAsync _productCategoryRepositoryAsync;
    private readonly IMapper _mapper;

    public ProductCategoryServiceAsync(IProductCategoryRepositoryAsync productCategoryRepositoryAsync , IMapper mapper)
    {
        _productCategoryRepositoryAsync = productCategoryRepositoryAsync;
        _mapper = mapper;
    }
    public async Task<int> InsertProductCategoryAsync(ProductCategoryRequestModel model)
    {
        ProductCategory pc = _mapper.Map<ProductCategory>(model);
        return await _productCategoryRepositoryAsync.InsertAsync(pc);
    }

    public async Task<IEnumerable<ProductCategoryResponseModel>> GetAllProductCategoryAsync()
    {
        return _mapper.Map<IEnumerable<ProductCategoryResponseModel>>(await _productCategoryRepositoryAsync.GetAllAsync());
    }
}