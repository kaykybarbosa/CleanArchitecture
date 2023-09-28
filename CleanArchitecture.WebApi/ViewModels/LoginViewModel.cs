using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.WebApi.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid format Email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Passoword is required.")]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max " + "{1} characters long.", MinimumLength = 8)]
        [DataType(DataType.Password)]   
        public string Password{ get; set; }

        public string? ReturnUrl { get; set; }
    }
}
