using System.ComponentModel.DataAnnotations;

namespace BLL.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "You must enter email")]
        [EmailAddress(ErrorMessage = "Incorrect syntax, example: \"example@gmail.com\"")]
        public string Email { get; set; }

        [Required(ErrorMessage = "You must enter password")]
        public string Password { get; set; }
    }
}
