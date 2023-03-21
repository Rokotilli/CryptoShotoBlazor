using System.ComponentModel.DataAnnotations;

namespace CryptoShoto.DTO
{
	public class RegistrationDTO
	{
		[Required]
		[EmailAddress]
		[StringLength(40)]
		public string Email { get; set; }

		[Required]
		[StringLength(15, MinimumLength = 3)]
		public string NickName { get; set; }

		[Required]
		//[RegularExpression("^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])$")]
		[StringLength(100, MinimumLength = 8)]
		public string Password { get; set; }

		[Required]
		[Compare("Password")]
		public string ConfirmPassword { get; set; }
	}
}
