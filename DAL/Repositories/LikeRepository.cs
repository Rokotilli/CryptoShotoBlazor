using DAL.Repositories;
using DAL.Models;
using DAL.Contracts;
using DAL.DBContext;

namespace DAL.Repositories;

public class LikeRepository : GenericRepository<Like>, ILikeRepository
{
    public LikeRepository(CSContext databaseContext)
        : base(databaseContext)
    {
    }

}