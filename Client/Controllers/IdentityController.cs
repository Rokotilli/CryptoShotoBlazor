using Client.Models;
using Client.Services;
using BLL.DTO;
using DAL.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using System.Security.Claims;

namespace Client.Controllers
{
    [Route("/api/identity")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IdentityService _identityService;

        public IdentityController(IdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost("SignIn")]
        public async Task<ActionResult> SignIn(ClaimModel model)
        {
            var claims = new List<Claim> { 
                new Claim("Email", model.Email), 
                new Claim(ClaimTypes.Name, model.Username), 
                new Claim("UID", model.UserId.ToString()) 
            };

			ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");

            await HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));

            return Ok();
        }

        [HttpPut("changename")]
        public async Task<ActionResult> ChangeName(ChangeNameModel user)
        {
            if (HttpContext.User.Identity is ClaimsIdentity claimsIdentity)
            {
                var nameClaim = claimsIdentity.FindFirst(ClaimTypes.Name);

                if (claimsIdentity.TryRemoveClaim(nameClaim))
                {
                    claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));

                    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                    await HttpContext.SignInAsync(claimsPrincipal);

                    await _identityService.ChangeName(user);

                    return Ok();
                }
            }

            return BadRequest();
        }

        [HttpPost]
        [Route("LogOut")]
        public async Task<ActionResult> LogOut()
        {
            await HttpContext.SignOutAsync("Cookies");
            return Ok();
        }
    }
}