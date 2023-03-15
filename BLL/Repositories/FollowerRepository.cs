using BLL.Repositories;
using DAL.Models;
using BLL.Contracts;
using DAL.DBContext;

namespace BLL.Repositories;

public class FollowerRepository : GenericRepository<Follower>, IFollowerRepository
{
    public FollowerRepository(CSContext databaseContext)
        : base(databaseContext)
    {
    }

}