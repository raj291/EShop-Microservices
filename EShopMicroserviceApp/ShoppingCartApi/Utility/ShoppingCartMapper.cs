using AutoMapper;
using ShopingCartApi.Core.Entity;
using ShopingCartApi.Core.Model.Request;
using ShopingCartApi.Core.Model.Response;

namespace ShoppingCartApi.Utility;

public class ShoppingCartMapper : Profile
{
    public ShoppingCartMapper()
    {
        CreateMap<ShoppingCartRequestModel, ShoppingCart>().ReverseMap();
        CreateMap<ShoppingCartResponseModel, ShoppingCart>().ReverseMap();
        CreateMap<ShoppingCartItemRequestModel, ShoppingCartItem>().ReverseMap();
        CreateMap<ShoppingCartItemResponseModel, ShoppingCartItem>().ReverseMap();
        CreateMap<PaymentTypeRequestModel, PaymentType>().ReverseMap();
        CreateMap<PaymentTypeResponseModel, PaymentType>().ReverseMap();
        CreateMap<PaymentMethodRequestModel, PaymentMethod>().ReverseMap();
        CreateMap<PaymentMethodResponseModel, PaymentMethod>().ReverseMap();
    }
}