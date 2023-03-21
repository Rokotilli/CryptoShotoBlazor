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

        [HttpPost("IsAuthenticated")]
        public async Task<ActionResult> CheckProfile(LoginDTO log)
        {
            var model = await unitOfWork.userRepository.SearchByEmail(log.Email);

            if (model == null || log.Password != model.Password)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpPost("Add")]
        public async Task<ActionResult> AddUser(RegistrationDTO reg)
        {
            if(await unitOfWork.userRepository.CheckEmailsForReg(reg.Email))
				return BadRequest("Почта занята");
			if (await unitOfWork.userRepository.CheckEmailsForReg(reg.NickName))
			    return BadRequest("Имя пользователя занято");

			User temp = mapper.Map<User>(reg);

			temp.RoleId = 1;

			await unitOfWork.userRepository.AddAsync(temp);

			await unitOfWork.SaveChangesAsync();

			return Ok();
        }
    }
}
