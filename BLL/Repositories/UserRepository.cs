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
}