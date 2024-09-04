using Authentication.Core.Entity;

namespace JwtAuthenticationManager;

public class AuthenticationResponse
{
    public string UserName { get; set; }
    public string JwtToken { get; set; }
    public int ExpireIn { get; set; }
    public ApplicationUser User { get; set; }
    
}