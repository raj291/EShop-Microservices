using Authentication.Core.Contracts.Repository;
using Authentication.Core.Entity;
using Authentication.Core.Model;
using Microsoft.AspNetCore.Identity;

namespace Authentication.Infrastructure;

public class AccountRepositoryAsync : IAccountRepositoryAsync
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AccountRepositoryAsync(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<IdentityResult> SignUpAsync(SignUpModel model)
    {
        ApplicationUser user = new ApplicationUser
        {
            UserName = model.Email,
            Email = model.Email,
            FirstName = model.FirstName,
            LastName = model.LastName
        };
       return await _userManager.CreateAsync(user, model.Password);
    }

    public async Task<SignInResult> LoginAsync(LoginModel model)
    {
       return await  _signInManager.PasswordSignInAsync(model.UserName, model.Password,false,false);
    }
}