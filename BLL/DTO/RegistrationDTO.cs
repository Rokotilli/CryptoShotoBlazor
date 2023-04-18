using System.ComponentModel.DataAnnotations;

namespace BLL.DTO
{
	public class RegistrationDTO
	{
        [Required(ErrorMessage = "You must enter email")]
        [EmailAddress(ErrorMessage = "Incorrect syntax, example: \"example@gmail.com\"")]
        [StringLength(40, ErrorMessage = "Max length 40 characters")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "You must enter username")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Max length 15 characters, minimum 3 characters")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "You must enter password")]
        [RegularExpression(@"^(?=.*\d)(?=.*[A-Z]).+$", ErrorMessage = "Password must contain at least one uppercase letter and a number")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Max length 100 characters, minimum 8 characters")]
        public string Password { get; set; }

        [Required(ErrorMessage = "You must confirm your password")]
        [Compare("Password", ErrorMessage = "Password must match")]
        public string ConfirmPassword { get; set; }
	}
}
