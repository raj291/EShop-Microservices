using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Authentication.Core.Entity;
using Authentication.Core.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace JwtAuthenticationManager;

public class JwtTokenHandler
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    public const string JWT_SECURITY_KEY = "HkoRQXAqdzJz3eg0fibXIZ5ugL9t8Gp1JTV6t5w52JEN3P342e3GwD85tBA2";
    private const int JWT_TOKEN_VALIDITY_MINS = 20;
    public JwtTokenHandler(UserManager<ApplicationUser> userManager , SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<AuthenticationResponse> GenerateToken(LoginModel request)
    {
        if (string.IsNullOrEmpty(request.UserName) || string.IsNullOrEmpty(request.Password))
        {
            return null;
        }

        var user = await _userManager.FindByEmailAsync(request.UserName);
        if (user == null || !await _userManager.CheckPasswordAsync(user, request.Password))
        {
            return null;
        }
        
        var tokenExpiryTimeTimeStamp = DateTime.Now.AddMinutes(JWT_TOKEN_VALIDITY_MINS);
        var tokenKey = Encoding.ASCII.GetBytes(JWT_SECURITY_KEY);
        var claimIdentity = new ClaimsIdentity(new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Name, user.UserName),
            new Claim(ClaimTypes.Role, "User")
        });

        var signingCredential = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature);

        var securityTokenDescriptor = new SecurityTokenDescriptor();// Attach Everything 
        securityTokenDescriptor.Subject = claimIdentity;
        securityTokenDescriptor.Expires = tokenExpiryTimeTimeStamp;
        securityTokenDescriptor.SigningCredentials = signingCredential;

        var securityTokenHandler = new JwtSecurityTokenHandler();
        var securityToken = securityTokenHandler.CreateToken(securityTokenDescriptor);
        var token = securityTokenHandler.WriteToken(securityToken);
        return new AuthenticationResponse
        {
            UserName = user.UserName,
            ExpireIn = (int)tokenExpiryTimeTimeStamp.Subtract(DateTime.Now).TotalSeconds,
            JwtToken = token
        };

    }
}