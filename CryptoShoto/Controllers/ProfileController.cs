using AutoMapper;
using DAL.Contracts;
using BLL.DTO;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using BLL.Contracts;

namespace BLL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        public readonly IProfileManager ProfileManager;

        public ProfileController(IProfileManager ProfileManager)
        {
            this.ProfileManager= ProfileManager;

        }

        [HttpPost("FoundingUser")]
        public async Task<ActionResult> CheckProfile(LoginDTO log)
        {
            var model = await ProfileManager.CheckProfile(log);

            if (model == false)
                return NotFound();

            return Ok();
        }

        [HttpPost("RegUser")]
        public async Task<ActionResult> AddUser(RegistrationDTO reg)
        {
            var result = await ProfileManager.AddUser(reg);

            if (result == false)
                return BadRequest();

			return Ok();
        }

        [HttpGet("CheckName/{name}")]
        public async Task<ActionResult> CheckName()
        {
            var result = await ProfileManager.CheckName(HttpContext.GetRouteValue("name").ToString());

            if (result == false)
                return BadRequest();

            return Ok();
        }

        [HttpGet("GetUserByEmail/{email}")]
        public async Task<ActionResult<User>> GetNameByEmail()
        {
            return Ok(await ProfileManager.GetNameByEmail(HttpContext.GetRouteValue("email").ToString()));
        }

        [HttpPut("ChangeName/{email}")]
        public async Task<ActionResult> ChangeName([FromBody]string username)
        {
            var result = await ProfileManager.ChangeName(username, HttpContext.GetRouteValue("email").ToString());

            if (result == false)
                return BadRequest();

            return Ok();
        }
    }
}
