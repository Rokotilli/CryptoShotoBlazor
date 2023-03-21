using Client.Services;
using CryptoShoto.DTO;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using System.Security.Claims;

namespace Client.Controllers
{
    [Route("/api/identity")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly LoginService _loginService;
        public IdentityController(LoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost("SignIn")]
        public async Task<ActionResult> SignIn(LoginDTO model)
        {
            if (await _loginService.LoginSend(model) == "OK") 
            {
                var claims = new List<Claim> { new Claim("Email", model.Email) };

				ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");

                await HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));

                return Ok();
            };

            return NotFound();
        }

        [HttpPost("SignUp")]
        public async Task<ActionResult> SignUp(RegistrationDTO model)
        {
            if (await _loginService.RegisterSend(model) == "OK")
            {
                var claims = new List<Claim> { new Claim("Email", model.Email) };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");

                await HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));

                return Ok();
            };

            return NotFound();
        }
    }
}