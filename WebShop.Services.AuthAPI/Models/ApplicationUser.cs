using Microsoft.AspNetCore.Identity;

namespace WebShop.Services.AuthAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
