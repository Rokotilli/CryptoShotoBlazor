using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Contracts
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> SearchByEmail(string email);

        Task<bool> CheckEmailsForReg(string email, string name);

	}
}
