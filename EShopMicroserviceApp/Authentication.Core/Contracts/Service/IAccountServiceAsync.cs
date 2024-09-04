using Authentication.Core.Model;
using Microsoft.AspNetCore.Identity;

namespace Authentication.Core.Contracts.Service;

public interface IAccountServiceAsync
{
    Task<IdentityResult> SignUpAsync(SignUpModel model);
    Task<string> LoginAsync(LoginModel model);
}