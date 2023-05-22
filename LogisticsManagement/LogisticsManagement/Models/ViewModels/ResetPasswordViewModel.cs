using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace LogisticsManagement.Models.ViewModels
{
    public class ResetPasswordViewModel
    {
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "Please enter your email")]
        [EmailAddress(ErrorMessage = "Email is not in correct format")]
        public string Email { get; set; }
    }
}
