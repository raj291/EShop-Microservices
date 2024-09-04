using AutoMapper;
using CustomerApi.Core.Entity;
using CustomerApi.Core.Model.Request;
using CustomerApi.Core.Model.Response;

namespace CustomerApi.Utility;

public class CustomerMapper : Profile
{
    public CustomerMapper()
    {
        CreateMap<Customer, CustomerResponseModel>().ReverseMap();
        CreateMap<Customer, CustomerRequestModel>().ReverseMap();
    }
}