using AutoMapper;
using BLL.Contracts;
using BLL.Repositories.Pagination;
using CryptoShoto.DTO;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace CryptoShoto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        private IMapper mapper;
        public readonly IUnitOfWork unitOfWork;

        public WalletController(IUnitOfWork unitOfWork, DTOService _mapperService)
        {
            this.unitOfWork = unitOfWork;
            _mapperService.CreateMapperWallet(ref mapper);
        }

        [HttpPost]
        public async Task<ActionResult> AddCoinForUser(WalletDTO wallet)
        {
            Wallet model = mapper.Map<Wallet>(wallet);

            try
            {
                await unitOfWork.walletRepository.AddAsync(model);
                await unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

            return Ok();
        }

        [HttpPut("countcoin/{id}")]
        public async Task<ActionResult<Wallet>> AddCountOfCointForUser(WalletDTO wallet)
        {
            Wallet model = mapper.Map<Wallet>(wallet);
            model.Id = int.Parse(HttpContext.GetRouteValue("id").ToString());
            await unitOfWork.walletRepository.UpdateAsync(model);
            await unitOfWork.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("GetIdByUserNameAndCoin/{UserId}/{CoinId}")] 
        public async Task<ActionResult<int>> GetIdByUserNameAndCoin(int UserId, int CoinId)
        {
            var a = await unitOfWork.walletRepository.GetIdByUserNameAndCoin(UserId, CoinId);
            return Ok(a);
        }
        [HttpGet("GetWalletsUser/{page}/{userid}")]
        public async Task<ActionResult<Pagination<Wallet>>> GetWalletsPaginated()
        {
            var wallets = await unitOfWork.walletRepository.GetWalletsByUserIdPaginated(int.Parse(HttpContext.GetRouteValue("page").ToString()), int.Parse(HttpContext.GetRouteValue("userid").ToString()));

            return Ok(wallets);
        }


        [HttpGet("GetWallets/{userid}")]
        public async Task<ActionResult<List<Wallet>>> GetWalletsAllByUser()
        {
            var wallets = await unitOfWork.walletRepository.GetWalletsByUserId(int.Parse(HttpContext.GetRouteValue("userid").ToString()));

            List<Wallet> temp = wallets.ToList();

            return Ok(temp);
        }

        [HttpGet("CheckCountOfCoin/{coinid}/{userid}")]
        public async Task<ActionResult<float>> CheckCountOfCoin()
        {
            var count = await unitOfWork.walletRepository.GetCountOfCoin(int.Parse(HttpContext.GetRouteValue("userid").ToString()), int.Parse(HttpContext.GetRouteValue("coinid").ToString()));

            return Ok(count);
        }
    }
}
