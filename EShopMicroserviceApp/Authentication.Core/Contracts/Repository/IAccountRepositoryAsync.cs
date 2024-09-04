using Authentication.Core.Model;
using Microsoft.AspNetCore.Identity;

namespace Authentication.Core.Contracts.Repository;

public interface IAccountRepositoryAsync
{
    Task<IdentityResult> SignUpAsync(SignUpModel model);
    Task<SignInResult> LoginAsync(LoginModel model);
}