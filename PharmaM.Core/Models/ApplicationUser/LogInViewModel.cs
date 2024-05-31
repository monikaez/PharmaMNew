using System.ComponentModel.DataAnnotations;
using static PharmaM.Core.Constants.MessageConstants;

namespace PharmaM.Core.Models.ApplicationUser
{
    public class LogInViewModel
    {
        [Display(Name = "Email Adress")]
        [Required(ErrorMessage = RequiredMessage)]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}
