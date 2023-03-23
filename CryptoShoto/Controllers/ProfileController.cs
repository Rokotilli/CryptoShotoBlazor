using AutoMapper;
using BLL.Contracts;
using CryptoShoto.DTO;
using DAL.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CryptoShoto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        public readonly IUnitOfWork unitOfWork;
		private IMapper mapper;

		public ProfileController(IUnitOfWork unitOfWork, DTOService _mapperService)
        {
            this.unitOfWork = unitOfWork;
            _mapperService.CreateMapperUser(ref mapper);
		}

        [HttpPost("FoundingUser")]
        public async Task<ActionResult> CheckProfile(LoginDTO log)
        {
            var model = await unitOfWork.userRepository.SearchByEmail(log.Email);

            if (model == null || log.Password != model.Password)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpPost("RegUser")]
        public async Task<ActionResult> AddUser(RegistrationDTO reg)
        {
            var result = await unitOfWork.userRepository.CheckEmailAndUserNameForReg(reg.Email, reg.UserName);

            if (result != null)
				return BadRequest(result);

			User temp = mapper.Map<User>(reg);

			temp.RoleId = 1;

			await unitOfWork.userRepository.AddAsync(temp);

			await unitOfWork.SaveChangesAsync();

			return Ok();
        }

        [HttpGet("CheckName/{name}")]
        public async Task<ActionResult> CheckName(string name)
        {
            
            var model = await unitOfWork.userRepository.SearchByName(name);
            
            if (model == null)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpGet("GetUserByEmail/{email}")]
        public async Task<ActionResult<User>> GetNameByEmail(string email)
        {
            return Ok(await unitOfWork.userRepository.SearchByEmail(email));
        }

        [HttpPut("ChangeName/{email}")]
        public async Task<ActionResult> ChangeName([FromBody]string username)
        {
            User user = new User();
            user = await unitOfWork.userRepository.SearchByEmail(HttpContext.GetRouteValue("email").ToString());
            user.UserName = username;

            await unitOfWork.userRepository.UpdateAsync(user);
            await unitOfWork.SaveChangesAsync();

            return Ok();
        }
    }
}
