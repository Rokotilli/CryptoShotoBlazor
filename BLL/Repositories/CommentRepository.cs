using BLL.Repositories;
using DAL.Models;
using BLL.Contracts;
using DAL.DBContext;

namespace BLL.Repositories;

public class CommentRepository : GenericRepository<Comment>, ICommentRepository
{
    public CommentRepository(CSContext databaseContext)
        : base(databaseContext)
    {
    }

}