using System.ComponentModel.DataAnnotations;

namespace CryptoShoto.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Вы должны ввести почту")]
        [EmailAddress(ErrorMessage = "Неправильный синтаксис, пример \"example@gmail.com\"")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Вы должны ввести пароль")]
        public string Password { get; set; }
    }
}
