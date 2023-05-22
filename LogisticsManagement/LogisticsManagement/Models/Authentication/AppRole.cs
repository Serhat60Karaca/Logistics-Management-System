using Microsoft.AspNetCore.Identity;

namespace LogisticsManagement.Models.Authentication
{
    public class AppRole : IdentityRole<int>
    {
        public DateTime CreateDate { get; set; }
    }
}
