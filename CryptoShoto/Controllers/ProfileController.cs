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

            Console.WriteLine(log.Email + log.Password+"YYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYY");

            return Ok();
        }

        [HttpGet("IsAuthenticated")]
        public bool IsAuthenticated()
        {
            return User.Identity.IsAuthenticated;
        }
    }
}
