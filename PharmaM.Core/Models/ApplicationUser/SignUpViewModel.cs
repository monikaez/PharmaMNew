using System.ComponentModel.DataAnnotations;

using static PharmaM.Core.Constants.MessageConstants;
namespace PharmaM.Core.Models.ApplicationUser
{
    public class SignUpViewModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        public string LastName { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        public string UserName { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        public string Address { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = RequiredMessage)]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = RequiredMessage)]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }
    }
}
