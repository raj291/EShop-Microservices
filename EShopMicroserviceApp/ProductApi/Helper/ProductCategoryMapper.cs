using AutoMapper;
using ProductApi.Core.Entity;
using ProductApi.Core.Models.Request;
using ProductApi.Core.Models.Response;

namespace ProductApi.Helper;

public class ProductCategoryMapper : Profile
{
    public ProductCategoryMapper()
    {
        CreateMap<ProductCategory, ProductCategoryRequestModel>().ReverseMap();
        CreateMap<ProductCategory, ProductCategoryResponseModel>().ReverseMap();
    }
    
}