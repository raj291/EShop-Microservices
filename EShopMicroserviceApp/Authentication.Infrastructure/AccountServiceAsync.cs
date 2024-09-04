using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Authentication.Core.Contracts.Repository;
using Authentication.Core.Contracts.Service;
using Authentication.Core.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Authentication.Infrastructure;

public class AccountServiceAsync : IAccountServiceAsync
{
    private readonly IAccountRepositoryAsync _accountRepositoryAsync;
    private readonly IConfiguration _configuration;

    public AccountServiceAsync(IAccountRepositoryAsync accountRepositoryAsync, IConfiguration configuration)
    {
        _accountRepositoryAsync = accountRepositoryAsync;
        _configuration = configuration;
    }
    public Task<IdentityResult> SignUpAsync(SignUpModel model)
    {
        return _accountRepositoryAsync.SignUpAsync(model);
    }

    public async Task<string> LoginAsync(LoginModel model)
    {
        var result = await _accountRepositoryAsync.LoginAsync(model);
        if (result.Succeeded)
        {
            var claim = new List<Claim>
            {
                new Claim(ClaimTypes.Name,model.UserName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())

            };
            var authkey =
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            var token = new JwtSecurityToken(
                issuer: "",
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddMinutes(20),
                claims: claim,
                signingCredentials: new SigningCredentials(authkey,SecurityAlgorithms.HmacSha256Signature)
            );

            var handler = new JwtSecurityTokenHandler().WriteToken(token);
            return handler;
        }
        return null;
    }
} 