using AutoMapper;
using BLL.Contracts;
using BLL.Repositories.Pagination;
using CryptoShoto.DTO;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CryptoShoto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        public readonly IUnitOfWork unitOfWork;
        private IMapper mapper;

        public PostsController(IUnitOfWork unitOfWork, DTOService _mapperService)
        {
            this.unitOfWork = unitOfWork;
            _mapperService.CreateMapperPost(ref mapper);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetPosts()
        {
            var model = await unitOfWork.postRepository.GetAllAsync();

            return Ok(model);
        }

        [HttpPost]
        public async Task<ActionResult<PostDTO>> AddPost(PostDTO model)
        {
            Post post = mapper.Map<Post>(model);

            var modelUser = await unitOfWork.userRepository.GetByIdAsync(model.UserId);
            
            post.UserId = modelUser.Id;
            post.Date = DateTime.Now;

            await unitOfWork.postRepository.AddAsync(post);
            await unitOfWork.SaveChangesAsync();

            return Ok();
        }

		[HttpDelete("{id}")]
		public async Task<ActionResult<PostDTO>> DeletePost()
        {
            await unitOfWork.postRepository.DeleteByIdAsync(int.Parse(HttpContext.GetRouteValue("id").ToString()));
            await unitOfWork.SaveChangesAsync();

            return Ok();
		}

        [HttpGet("myposts/{userid}")]
        public async Task<ActionResult<List<Post>>> GetAllPostsByUserId()
        {
            var model = await unitOfWork.postRepository.PostGetByUserId(int.Parse(HttpContext.GetRouteValue("userid").ToString()));   

            List<Post> temp = model.ToList();

            return Ok(temp);
        }

        [HttpGet("GetPagedPosts/{page}/{userid}")]
        public async Task<ActionResult<Pagination<Post>>> GetPagedPosts()
        {
            var result = await unitOfWork.postRepository.PagedPosts(int.Parse(HttpContext.GetRouteValue("page").ToString()), int.Parse(HttpContext.GetRouteValue("userid").ToString()));

            return Ok(result);
        }
    }
}
