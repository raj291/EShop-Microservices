using Microsoft.AspNetCore.Mvc;
using ProductApi.Core.Contracts.Services;
using ProductApi.Core.Models.Request;

namespace ProductApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductCategoryController : ControllerBase
{
    private readonly IProductCategoryServiceAsync _productCategoryServiceAsync;

    public ProductCategoryController(IProductCategoryServiceAsync productCategoryServiceAsync)
    {
        _productCategoryServiceAsync = productCategoryServiceAsync;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        return Ok(await _productCategoryServiceAsync.GetAllProductCategoryAsync());
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(ProductCategoryRequestModel model)
    {
        return Ok(await _productCategoryServiceAsync.InsertProductCategoryAsync(model));
    }
}