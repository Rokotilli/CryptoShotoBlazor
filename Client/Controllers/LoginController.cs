using Client.Services;
using CryptoShoto.DTO;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Client.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly LoginService _loginService;
        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public async Task<ActionResult> Login([FromForm] string Email, [FromForm] string Password)
        {
            LoginDTO loginDTO = new LoginDTO()
            {
                Email = Email,
                Password = Password
            };

            if (await _loginService.LoginSend(loginDTO) == true) 
            {
				var claims = new List<Claim> { new Claim("Email", Email) };

				ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");

                await HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));

                return Redirect("/");
            };

            return Redirect("/login");
        }

    }
}