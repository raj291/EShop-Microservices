using Authentication.Core.Contracts.Service;
using Authentication.Core.Model;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationApi.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class AccountController : ControllerBase
{

    private readonly IAccountServiceAsync _accountServiceAsync;

    public AccountController(IAccountServiceAsync accountServiceAsync)
    {
        _accountServiceAsync = accountServiceAsync;
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginModel model)
    {
        var token = await _accountServiceAsync.LoginAsync(model);
        if (token == null)
        {
            return Unauthorized();
        }

        return Ok(token);
    }

    [HttpPost]
    public async Task<IActionResult> SignUp(SignUpModel model)
    {
       var result = await _accountServiceAsync.SignUpAsync(model);
       if (result.Succeeded)
       {
           return Ok("Account Created");
       }
       else
       {
           return BadRequest(result.Errors);
       }
    }
}