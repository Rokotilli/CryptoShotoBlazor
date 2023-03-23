using System.ComponentModel.DataAnnotations;

namespace CryptoShoto.DTO
{
	public class RegistrationDTO
	{
        [Required(ErrorMessage = "Вы должны ввести почту")]
        [EmailAddress(ErrorMessage = "Неправильный синтаксис, пример \"example@gmail.com\"")]
        [StringLength(40, ErrorMessage = "Максимальная длина 40 символов")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Вы должны ввести имя пользователя")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Максимальная длина 15, минимальная 3 символа")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Вы должны ввести пароль")]
        [RegularExpression(@"^(?=.*\d)(?=.*[A-Z]).+$", ErrorMessage = "Пароль должен местить как минимум одну заглавную букву и цифру")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Максимальная длина 100, минимальная 8 символов")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Вы должны повторить пароль")]
        [Compare("Password", ErrorMessage = "Пароли должны совпадать")]
        public string ConfirmPassword { get; set; }
	}
}
