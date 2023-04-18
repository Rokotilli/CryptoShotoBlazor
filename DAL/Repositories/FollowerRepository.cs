using DAL.Repositories;
using DAL.Models;
using DAL.Contracts;
using DAL.DBContext;

namespace DAL.Repositories;

public class FollowerRepository : GenericRepository<Follower>, IFollowerRepository
{
    public FollowerRepository(CSContext databaseContext)
        : base(databaseContext)
    {
    }

}