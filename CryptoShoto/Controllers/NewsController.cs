using BLL.Contracts;
using BLL.Repositories.Pagination;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace CryptoShoto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        public readonly IUnitOfWork unitOfWork;

        public NewsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<News>>> GetNewsAsync()
        {
            var model = await unitOfWork.newsRepository.GetAllAsync();

            return Ok(model);
        }

        [HttpGet("GetLatestNew")]
        public async Task<ActionResult<News>> GetLatestNew()
        {
            var model = await unitOfWork.newsRepository.GetLatestNew();

            News temp = await unitOfWork.newsRepository.GetByIdAsync(model);

            return Ok(temp);
        }

        [HttpGet("GetPagedNews/{page}")]
        public async Task<ActionResult<Pagination<News>>> GetPagedNews()
        {
            var result = await unitOfWork.newsRepository.PagedNews(int.Parse(HttpContext.GetRouteValue("page").ToString()));

            return Ok(result);
        }
    }
}
