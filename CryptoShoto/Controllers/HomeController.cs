
using BLL;
using BLL.Contracts;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Lab3.Controllers
{
    public class HomeController : Controller
    {
        public readonly IUnitOfWork unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<ActionResult<IEnumerable<Coin>>> Index()
        {
            var all = await unitOfWork.coinRepository.GetAllAsync();

            return View(all);
        }
    }
}
