using AutoMapper;
using BLL.Contracts;
using BLL.DTO;
using DAL.Contracts;
using DAL.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Managers
{
    public class ProfileManager : IProfileManager
    {
        public readonly IUnitOfWork unitOfWork;
        private IMapper mapper;

        public ProfileManager(IUnitOfWork unitOfWork, DTOService _mapperService)
        {
            this.unitOfWork = unitOfWork;
            _mapperService.CreateMapperUser(ref mapper);
        }

        public async Task<User> GetNameByEmail(string email) 
        {
            var result = await unitOfWork.userRepository.SearchByEmail(email);
            return result;
        }

        public async Task<bool> AddUser(RegistrationDTO reg)
        {
            try
            {
                var result = await unitOfWork.userRepository.CheckEmailAndUserNameForReg(reg.Email, reg.UserName);

                if (result != null)
                    return false;

                User temp = mapper.Map<User>(reg);

                temp.RoleId = 1;

                await unitOfWork.userRepository.AddAsync(temp);

                await unitOfWork.SaveChangesAsync();

                return true;
            }
            catch { return false; }
        }

        public async Task<bool> ChangeName(string username, string email)
        {
            try
            {
                User user = new User();
                user = await unitOfWork.userRepository.SearchByEmail(email);
                user.UserName = username;

                await unitOfWork.userRepository.UpdateAsync(user);
                await unitOfWork.SaveChangesAsync();
                return true;
            }
            catch { return false; }
        }

        public async Task<bool> CheckName(string name)
        {
            var model = await unitOfWork.userRepository.SearchByName(name);

            if (model == null)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> CheckProfile(LoginDTO log)
        {
            var model = await unitOfWork.userRepository.SearchByEmail(log.Email);

            if (model == null || log.Password != model.Password)
            {
                return false;
            }
            return true;
        }
    }
}
