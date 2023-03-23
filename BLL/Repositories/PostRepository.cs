using BLL.Repositories;
using DAL.Models;
using BLL.Contracts;
using DAL.DBContext;
using BLL.Repositories.Pagination;

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

    public async Task<Pagination<Post>> PagedPosts(int page, int userid)
    {
        var posts = await PostGetByUserId(userid);

        var paged_list_posts = await Pagination<Post>.ToPagedListAsync(posts, page);

        return paged_list_posts;
    }
}