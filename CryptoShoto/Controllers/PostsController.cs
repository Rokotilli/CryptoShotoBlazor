using DAL.Contracts;
using DAL.Repositories.Pagination;
using BLL.DTO;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using BLL.Contracts;

namespace BLL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        public readonly IPostManager PostManager;

        public PostsController(IPostManager PostManager)
        {
            this.PostManager = PostManager;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetPosts()
        {
            var result = await PostManager.GetPosts();

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> AddPost(PostDTO model)
        {
            var result = await PostManager.AddPost(model);

            if (result == true)
                return Ok();

            return BadRequest();
        }

		[HttpDelete("{id}")]
		public async Task<ActionResult> DeletePost()
        {
            var result = await PostManager.DeletePost(int.Parse(HttpContext.GetRouteValue("id").ToString()));

            if (result == true)
                return Ok();

            return BadRequest();
		}

        [HttpGet("myposts/{userid}")]
        public async Task<ActionResult<List<Post>>> GetAllPostsByUserId()
        {
            var result = await PostManager.GetAllPostsByUserId(int.Parse(HttpContext.GetRouteValue("userid").ToString()));

            return Ok(result);
        }

        [HttpGet("GetPagedPosts/{page}/{userid}")]
        public async Task<ActionResult<Pagination<Post>>> GetPagedPosts()
        {
            var result = await PostManager.GetPagedPosts(int.Parse(HttpContext.GetRouteValue("page").ToString()), int.Parse(HttpContext.GetRouteValue("userid").ToString()));

            return Ok(result);
        }
    }
}
