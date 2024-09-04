using Microsoft.AspNetCore.Identity;

namespace Authentication.Core.Entity;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
    
}