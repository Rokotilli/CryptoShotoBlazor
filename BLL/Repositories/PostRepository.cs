using BLL.Repositories;
using DAL.Models;
using BLL.Contracts;
using DAL.DBContext;

namespace BLL.Repositories;

public class PostRepository : GenericRepository<Post>, IPostRepository
{
    public PostRepository(CSContext databaseContext)
        : base(databaseContext)
    {
    }

    public async Task<IQueryable<Post>> PostGetByUserId(int id)
    {
        var posts = databaseContext.Posts.Where(p => p.UserId == id);

        return posts;
    }

}