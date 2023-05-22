using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogisticsManagement.Models.Authentication
{
    public class AppUser : IdentityUser<int>
    {
        public string? Country { get; set; }
        public bool? Gender { get; set; }  
    }
}
