using DAL.Contracts;
using DAL.Repositories.Pagination;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using BLL.Contracts;

namespace BLL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        public readonly INewsManager NewsManager;

        public NewsController(INewsManager newsManager)
        {
            NewsManager = newsManager;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<News>>> GetNewsAsync()
        {
            var result = await NewsManager.GetNewsAsync();

            return Ok(result);
        }

        [HttpGet("GetLatestNew")]
        public async Task<ActionResult<News>> GetLatestNew()
        {
            var result = await NewsManager.GetLatestNew();

            return Ok(result);
        }

        [HttpGet("GetPagedNews/{page}")]
        public async Task<ActionResult<Pagination<News>>> GetPagedNews()
        {
            var result = await NewsManager.GetPagedNews(int.Parse(HttpContext.GetRouteValue("page").ToString()));

            return Ok(result);
        }
    }
}
