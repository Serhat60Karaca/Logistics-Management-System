using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace LogisticsManagement.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please enter your email address")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email is not in correct format")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter your password")]
        [DataType(DataType.Password, ErrorMessage = "Password is not in correct format.")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me")]
        public bool Persistent { get; set; }
        public bool Lock { get; set; }
    }
}
