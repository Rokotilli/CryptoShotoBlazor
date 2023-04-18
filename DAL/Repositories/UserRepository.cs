using DAL.Repositories;
using DAL.Models;
using DAL.Contracts;
using DAL.DBContext;

namespace DAL.Repositories;

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

    public async Task<User> SearchByName(string name)
    {
        var user = databaseContext.Users.FirstOrDefault(u => u.UserName == name);

        return user;
    }


    public async Task<string> CheckEmailAndUserNameForReg(string email, string username)
	{
        var Email = databaseContext.Users.FirstOrDefault(u => u.Email == email);

        var Username = databaseContext.Users.FirstOrDefault(u => u.UserName == username);

        if (Email != null && Username != null)
            return "Email and username are taken";
        else if (Email != null)
            return "Email is taken";
        else if (Username != null)
            return "Username is taken";
        else
            return null;
    }

}