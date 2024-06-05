using Microsoft.AspNetCore.Identity;

namespace Polling_Page_Administration_Task.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }
    }
}
