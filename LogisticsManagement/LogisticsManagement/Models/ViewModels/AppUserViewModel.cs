using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace LogisticsManagement.Models.ViewModels
{
    public class AppUserViewModel
    {

        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
