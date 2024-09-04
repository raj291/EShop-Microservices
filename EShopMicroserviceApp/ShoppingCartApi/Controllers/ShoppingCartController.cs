using Microsoft.AspNetCore.Mvc;
using ShopingCartApi.Core.Contracts.Service;
using ShopingCartApi.Core.Model.Request;

namespace ShoppingCartApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ShoppingCartController : ControllerBase
{
    private readonly IPaymentTypeServiceAsync _paymentTypeServiceAsync;
    private readonly IPaymentMethodServiceAsync _paymentMethodServiceAsync;
    private readonly IShoppingCartServiceAsync _shoppingCartServiceAsync;
    private readonly IShoppingCartItemServiceAsync _shoppingCartItemServiceAsync;

    public ShoppingCartController(IPaymentTypeServiceAsync paymentTypeServiceAsync, IPaymentMethodServiceAsync paymentMethodServiceAsync, IShoppingCartServiceAsync shoppingCartServiceAsync, IShoppingCartItemServiceAsync shoppingCartItemServiceAsync)
    {
        _paymentTypeServiceAsync = paymentTypeServiceAsync;
        _paymentMethodServiceAsync = paymentMethodServiceAsync;
        _shoppingCartServiceAsync = shoppingCartServiceAsync;
        _shoppingCartItemServiceAsync = shoppingCartItemServiceAsync;
    }


    [HttpGet("GetAllPaymentType")]
    public async Task<IActionResult> GetPaymentType()
    {
        return Ok(await _paymentTypeServiceAsync.GetAllPaymentTypeAsync());
    }

    [HttpPost("InsertPaymentMethods")]
    public async Task<IActionResult> InsertPaymentMethod(PaymentMethodRequestModel model)
    {
        return Ok(await _paymentMethodServiceAsync.GetAllPaymentMethodAsync());
    }
}