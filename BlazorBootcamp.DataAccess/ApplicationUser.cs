using Microsoft.AspNetCore.Identity;

namespace BlazorBootcamp.DataAccess
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
