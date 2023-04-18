using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contracts
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> SearchByEmail(string email);

        Task<string> CheckEmailAndUserNameForReg(string email, string username);

        Task<User> SearchByName(string name);
    }
}
