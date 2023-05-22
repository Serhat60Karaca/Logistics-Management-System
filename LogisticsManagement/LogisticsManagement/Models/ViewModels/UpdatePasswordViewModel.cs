using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace LogisticsManagement.Models.ViewModels
{
    public class UpdatePasswordViewModel
    {
        [Display(Name = "New Password")]
        [Required(ErrorMessage = "Please enter your password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
