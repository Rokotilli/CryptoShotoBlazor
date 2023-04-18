using DAL.Contracts;
using DAL.Repositories.Pagination;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using BLL.Contracts;

namespace BLL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoinController : ControllerBase
    {        
        public readonly ICoinManager CoinManager;

        public CoinController(ICoinManager coinmanager)
        {
            CoinManager = coinmanager;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Coin>>> GetCoinsAsync()
        {
            var result = await CoinManager.GetCoinsAsync();

            return Ok(result);
        }

        [HttpGet("GetPagedCoins/{page}")]
        public async Task<ActionResult<Pagination<Coin>>> GetPagedCoins()
        {
            var result = await CoinManager.GetPagedCoins(int.Parse(HttpContext.GetRouteValue("page").ToString()));

            return Ok(result);
        }
    }
}
