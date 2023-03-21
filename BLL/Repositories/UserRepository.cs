using BLL.Repositories;
using DAL.Models;
using BLL.Contracts;
using DAL.DBContext;

namespace BLL.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(CSContext databaseContext)
        : base(databaseContext)
    {
    }

    public async Task<User> SearchByEmail(string email)
    {
        var user = databaseContext.Users.FirstOrDefault(u => u.Email == email);

        return user;
    }

	public async Task<bool> CheckEmailsForReg(string email)
	{
		var user = databaseContext.Users.FirstOrDefault(u => u.Email == email);

		if (user != null)
            return true;
        return false;
	}

    public async Task<bool> CheckUserNameForReg(string username)
    {
		var user = databaseContext.Users.FirstOrDefault(u => u.UserName == username);

		if (user != null)
			return true;
		return false;
	}
}