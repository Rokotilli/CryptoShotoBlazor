using DAL.Repositories.Pagination;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using DAL.Models;

namespace BLL.Contracts
{
    public interface IPostManager
    {
        public  Task<IEnumerable<Post>> GetPosts();

        public  Task<bool> AddPost(PostDTO model);

        public  Task<bool> DeletePost(int id);

        public  Task<List<Post>> GetAllPostsByUserId(int id);

        public  Task<Pagination<Post>> GetPagedPosts(int page, int userid);
    }
}
