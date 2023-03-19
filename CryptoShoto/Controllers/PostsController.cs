using AutoMapper;
using BLL.Contracts;
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

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<PostDTO>> AddPost([FromBody] PostDTO model)
        {
            Post post = mapper.Map<Post>(model);

            var modelUser = await unitOfWork.userRepository.SearchByEmail(HttpContext.User.Identity.Name);
            
            post.UserId = modelUser.Id;
            post.Date = DateTime.Now;

            await unitOfWork.postRepository.AddAsync(post);
            await unitOfWork.SaveChangesAsync();

            return Ok();
        }

		[HttpDelete("{id}")]
		public async Task<ActionResult<PostDTO>> DeletePost(int id)
        {
            await unitOfWork.postRepository.DeleteByIdAsync(id);
            await unitOfWork.SaveChangesAsync();

            return Ok();
		}

        [HttpGet("myposts")]
        public async Task<ActionResult<List<PostDTO>>> GetAllPostsByUserId()
        {
            var modelUser = await unitOfWork.userRepository.SearchByEmail(HttpContext.User.Identity.Name);

            var model = await unitOfWork.postRepository.PostGetByUserId(modelUser.Id);   

            List<Post> temp = model.ToList();

            return Ok();
        }
    }
}
