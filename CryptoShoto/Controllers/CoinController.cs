using BLL;
using BLL.Contracts;
using BLL.Repositories.Pagination;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CryptoShoto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoinController : ControllerBase
    {
        public readonly IUnitOfWork unitOfWork;

        public CoinController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Coin>>> GetCoinsAsync()
        {
            var model = await unitOfWork.coinRepository.GetAllAsync();

            return Ok(model);
        }

        [HttpGet("GetPagedCoins/{page}")]
        public async Task<ActionResult<Pagination<News>>> GetPagedCoins()
        {
            var result = await unitOfWork.coinRepository.PagedCoins(int.Parse(HttpContext.GetRouteValue("page").ToString()));

            return Ok(result);
        }
    }
}
