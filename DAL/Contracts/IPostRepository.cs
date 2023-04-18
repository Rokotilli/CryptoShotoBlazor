using DAL.Repositories.Pagination;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contracts
{
    public interface IPostRepository : IGenericRepository<Post>
    {
        Task<IQueryable<Post>> PostGetByUserId(int id);

        Task<Pagination<Post>> PagedPosts(int page, int userid);
    }
}
