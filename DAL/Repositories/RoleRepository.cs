using DAL.Repositories;
using DAL.Models;
using DAL.Contracts;
using DAL.DBContext;

namespace DAL.Repositories;

public class RoleRepository : GenericRepository<Role>, IRoleRepository
{
    public RoleRepository(CSContext databaseContext)
        : base(databaseContext)
    {
    }

}