using Client.Services;
using CryptoShoto.DTO;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Client.Controllers
{
	[Route("/[controller]")]
	[ApiController]
	public class RegisterController : ControllerBase
	{
		private readonly LoginService _loginService;
		public RegisterController(LoginService loginService)
		{
			_loginService = loginService;
		}

		[HttpPost]
		public async Task<ActionResult> Register([FromForm] string email, [FromForm] string name, [FromForm] string password, [FromForm] string password2)
		{
			
			RegistrationDTO reg = new RegistrationDTO()
			{
				NickName= name,
				Email = email,
				Password = password,
				ConfirmPassword	= password2
			};

			if (await _loginService.RegisterSend(reg)==true)
			{
                
                var claims = new List<Claim> { new Claim("Email", email), new Claim(ClaimTypes.Name, name) };

				ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");

				await HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));

				return Redirect("/");
			}
			return Redirect("/register");
		}


       
       
	}
}