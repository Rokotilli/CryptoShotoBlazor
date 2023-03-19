using BLL.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CryptoShoto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletController : Controller
    {
        public readonly IUnitOfWork unitOfWork;

        public WalletController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
    }
}
