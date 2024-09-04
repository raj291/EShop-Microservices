using CustomerApi.Core.Contracts.Services;
using CustomerApi.Core.Model.Request;
using CustomerApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace CustomerApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ICustomerServiceAsync _customerServiceAsync;

    public CustomerController(ICustomerServiceAsync customerServiceAsync)
    {
        _customerServiceAsync = customerServiceAsync;
    }
    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        return Ok(await _customerServiceAsync.GetAllCustomerAsync());

    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(CustomerRequestModel model)
    {
        return Ok(await _customerServiceAsync.InsertCustomerAsync(model));
    }

    [HttpGet("GetProductCategories")]
    public async Task<IActionResult> GetProductAsyn()
    {
        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri("http://host.docker.internal:50124/api");
        HttpResponseMessage message = await client.GetAsync("api/ProductCategory");
        if (message != null)
        {
            if (message.IsSuccessStatusCode)
            {
                var result = await message.Content.ReadFromJsonAsync<List<ProductCategory>>();
                return  Ok(result);
            }
        }

        return NoContent();
    }
    
    
}