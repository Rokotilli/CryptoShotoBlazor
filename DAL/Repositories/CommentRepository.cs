using DAL.Repositories;
using DAL.Models;
using DAL.Contracts;
using DAL.DBContext;

namespace DAL.Repositories;

public class CommentRepository : GenericRepository<Comment>, ICommentRepository
{
    public CommentRepository(CSContext databaseContext)
        : base(databaseContext)
    {
    }

}