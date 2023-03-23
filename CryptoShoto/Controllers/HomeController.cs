using BLL;
using BLL.Contracts;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CryptoShoto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        public readonly IUnitOfWork unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Coin>>> Index()
        {
            var all = await unitOfWork.coinRepository.GetAllAsync();

            return Ok(all);
        }
    }
}
