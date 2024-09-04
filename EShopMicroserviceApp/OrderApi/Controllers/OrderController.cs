using Microsoft.AspNetCore.Mvc;
using OrderApi.Core.Contracts.Services;
using OrderApi.Core.Entity;
using OrderApi.Core.Models.Request;
using OrderApi.Core.Models.Response;
using OrderApi.MessagingService;
using SharedServiceMessage;

namespace OrderApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IOrderServiceAsync _orderServiceAsync;
    private readonly IOrderDetailsServiceAsync _orderDetailsServiceAsync;
    private QueueService _queueService;

    public OrderController(IOrderServiceAsync orderServiceAsync, IOrderDetailsServiceAsync orderDetailsServiceAsync, IConfiguration configuration)
    {
        _orderServiceAsync = orderServiceAsync;
        _orderDetailsServiceAsync = orderDetailsServiceAsync;
        _queueService = new QueueService(configuration);
    }

    [HttpGet("GetAllOrders")]
    public async Task<IActionResult> GetOrderAsync()
    {
        return Ok(await _orderServiceAsync.GetAllOrdersAsync());
    }

    [HttpGet("GetAllOrderDetails")]
    public async Task<IActionResult> GetOrdetailsAsync()
    {
        return Ok(await _orderDetailsServiceAsync.GetAllOrderDetailsAsync());
    }

    [HttpGet("GetOrderById")]
    public async Task<IActionResult> GetOrderByIdAsync(int id)
    {
        return Ok(await _orderServiceAsync.GetOrderByIdAsync(id));
    }

    [HttpGet("GetOrderDetailsById")]
    public async Task<IActionResult> GetOrderDetailByIdAysnc(int id)
    {
        return Ok(await _orderDetailsServiceAsync.GetOrderDetailByIdAsync(id));
    }

    [HttpPost("AddOrder")]
    public async Task<IActionResult> InsertOrder(OrderRequestModel model)
    {
        return Ok(await _orderServiceAsync.InsertOrderAsync(model));
    }

    [HttpPost("AddOrderDetails")]
    public async Task<IActionResult> InsertOrderDetails(OrderDetailsRequestModel model)
    {
        return Ok(await _orderDetailsServiceAsync.InsertOrderDetailsAsync(model));
    }

    [HttpPost("Message")]
    public async Task<IActionResult> PostMessage(Orderdetails orderDetails)
    {
        await _queueService.SendMessageAsync<Orderdetails>(orderDetails, "orderqueue");
        return Ok("Message has been send");
    }
}