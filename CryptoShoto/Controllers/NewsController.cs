using BLL.Contracts;
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
    }
}
