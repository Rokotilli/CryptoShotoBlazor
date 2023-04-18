using BLL.DTO;
using DAL.Models;
using DAL.Repositories.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Contracts
{
    public interface IWalletManager
    {
        public Task<bool> AddCoinForUser(WalletDTO wallet);

        public Task<bool> AddCountOfCointForUser(WalletDTO wallet, int id);

        public Task<int> GetIdByUserNameAndCoin(int UserId, int CoinId);

        public Task<Pagination<Wallet>> GetWalletsPaginated(int page, int userid);

        public Task<List<Wallet>> GetWalletsAllByUser(int userid);

        public Task<float> CheckCountOfCoin(int userid, int coinid);
    }
}
