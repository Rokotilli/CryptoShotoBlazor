using BLL;
using BLL.Contracts;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Lab3.Controllers
{
    //[Route("[controller]")]
    //[ApiController]
    public class CoinController : Controller
    {
        public readonly IUnitOfWork unitOfWork;

        public CoinController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        //[HttpGet("Index")]
        public async Task<ActionResult<IEnumerable<Coin>>> Index()
        {
            var all = await unitOfWork.coinRepository.GetAllAsync();

            return View(all);
        }
    }
}
