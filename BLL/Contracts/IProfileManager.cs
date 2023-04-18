using BLL.DTO;
using DAL.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Contracts
{
    public interface IProfileManager
    {
        public Task<bool> CheckProfile(LoginDTO log);

        public Task<bool> AddUser(RegistrationDTO reg);

        public Task<bool> CheckName(string name);

        public Task<User> GetNameByEmail(string email);

        public Task<bool> ChangeName(string username, string email);
    }
}
