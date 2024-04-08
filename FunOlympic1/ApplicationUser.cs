using Microsoft.AspNetCore.Identity;

namespace FunOlympic1
{
    public class ApplicationUser : IdentityUser
    {
        public string? Name { get; set; }
        public string? Country { get; set; }
        public string? Interest { get; set; }

    }
}
