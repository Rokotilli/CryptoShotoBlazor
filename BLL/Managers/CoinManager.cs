using BLL.Contracts;
using DAL.Contracts;
using DAL.Models;
using DAL.Repositories;
using DAL.Repositories.Pagination;
using System.Net.Http;

namespace BLL.Managers
{
    public class CoinManager : ICoinManager
    {
        public IUnitOfWork UnitOfWork { get; }

        public CoinManager(IUnitOfWork UnitOfWork)
        {
            this.UnitOfWork = UnitOfWork;
        }

        public async Task<IEnumerable<Coin>> GetCoinsAsync()
        {
            var model = await UnitOfWork.coinRepository.GetAllAsync();

            return model;
        }

        public async Task<Pagination<Coin>> GetPagedCoins(int page)
        {
            var model = await UnitOfWork.coinRepository.PagedCoins(page);

            return model;
        }
    }
}