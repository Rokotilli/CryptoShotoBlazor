using BLL.Contracts;
using DAL.Contracts;
using DAL.Models;
using DAL.Repositories;
using DAL.Repositories.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using AutoMapper;

namespace BLL.Managers
{
    public class PostManager : IPostManager
    {

        public IUnitOfWork UnitOfWork { get; }
        private IMapper mapper;

        public PostManager(IUnitOfWork UnitOfWork, DTOService _mapperService)
        {
            this.UnitOfWork = UnitOfWork;
            _mapperService.CreateMapperPost(ref mapper);
        }

        public async Task<bool> AddPost(PostDTO model)
        {
            try
            {
                Post post = mapper.Map<Post>(model);

                var modelUser = await UnitOfWork.userRepository.GetByIdAsync(model.UserId);

                post.UserId = modelUser.Id;
                post.Date = DateTime.Now;

                await UnitOfWork.postRepository.AddAsync(post);
                await UnitOfWork.SaveChangesAsync();

                return true;
            }
            catch 
            { 
                return false; 
            }
        }

        public async Task<bool> DeletePost(int id)
        {
            try
            {
                await UnitOfWork.postRepository.DeleteByIdAsync(id);
                await UnitOfWork.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<Post>> GetAllPostsByUserId(int id)
        {
            var model = await UnitOfWork.postRepository.PostGetByUserId(id);

            List<Post> temp = model.ToList();

            return temp;
        }

        public async Task<Pagination<Post>> GetPagedPosts(int page, int userid)
        {
            var result = await UnitOfWork.postRepository.PagedPosts(page, userid);

            return result;
        }

        public async Task<IEnumerable<Post>> GetPosts()
        {
            var model = await UnitOfWork.postRepository.GetAllAsync();

            return model;
        }
    }
}
