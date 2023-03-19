using BLL.Contracts;
using CryptoShoto.DTO;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CryptoShoto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        public readonly IUnitOfWork unitOfWork;

        public ProfileController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<ActionResult<LoginDTO>> Login(LoginDTO log)
        {
            var model = await unitOfWork.userRepository.SearchByEmail(log.Email);

            if (model == null && log.Password != model.Password)
            {
                return Unauthorized();
            }

            var claims = new List<Claim> { new Claim(ClaimTypes.Name, model.Email) };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            return Ok();
        }

        [HttpGet("IsAuthenticated")]
        public bool IsAuthenticated()
        {
            return User.Identity.IsAuthenticated;
        }
    }
}
