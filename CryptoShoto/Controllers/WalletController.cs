using AutoMapper;
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
    public class WalletController : ControllerBase
    {
        public readonly IWalletManager walletManager;

        public WalletController(IWalletManager walletManager)
        {
            this.walletManager = walletManager;
        }

        [HttpPost]
        public async Task<ActionResult> AddCoinForUser(WalletDTO wallet)
        {
            var result = await walletManager.AddCoinForUser(wallet);

            if (result == false)
                return BadRequest();

            return Ok();
        }

        [HttpPut("countcoin/{id}")]
        public async Task<ActionResult<Wallet>> AddCountOfCointForUser(WalletDTO wallet)
        {
            var result = await walletManager.AddCountOfCointForUser(wallet, int.Parse(HttpContext.GetRouteValue("userid").ToString()));

            if(result == false)
                return BadRequest();

            return Ok();
        }

        [HttpGet("GetIdByUserNameAndCoin/{UserId}/{CoinId}")] 
        public async Task<ActionResult<int>> GetIdByUserNameAndCoin()
        {
            var result = await walletManager.GetIdByUserNameAndCoin(int.Parse(HttpContext.GetRouteValue("UserId").ToString()), int.Parse(HttpContext.GetRouteValue("CoinId").ToString()));

            return Ok(result);
        }

        [HttpGet("GetWalletsUser/{page}/{userid}")]
        public async Task<ActionResult<Pagination<Wallet>>> GetWalletsPaginated()
        {
            var result = await walletManager.GetWalletsPaginated(int.Parse(HttpContext.GetRouteValue("page").ToString()), int.Parse(HttpContext.GetRouteValue("userid").ToString()));

            return Ok(result);
        }

        [HttpGet("GetWallets/{userid}")]
        public async Task<ActionResult<List<Wallet>>> GetWalletsAllByUser()
        {
            var result = await walletManager.GetWalletsAllByUser(int.Parse(HttpContext.GetRouteValue("userid").ToString()));

            return Ok(result);
        }

        [HttpGet("CheckCountOfCoin/{coinid}/{userid}")]
        public async Task<ActionResult<float>> CheckCountOfCoin()
        { 
            var result = await walletManager.CheckCountOfCoin(int.Parse(HttpContext.GetRouteValue("userid").ToString()), int.Parse(HttpContext.GetRouteValue("coinid").ToString()));

            return Ok(result);
        }
    }
}
