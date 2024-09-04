using AutoMapper;
using OrderApi.Core.Entity;
using OrderApi.Core.Models.Request;
using OrderApi.Core.Models.Response;

namespace OrderApi.Utility;

public class OrderMapper : Profile
{
    public OrderMapper()
    {
        CreateMap<OrderRequestModel, Order>().ReverseMap();
        CreateMap<OrderResponseModel, Order>().ReverseMap();
        CreateMap<OrderDetailsRequestModel, OrderDetails>().ReverseMap();
        CreateMap<OrderDetailsResponseModel, OrderDetails>().ReverseMap();
    }
    
}