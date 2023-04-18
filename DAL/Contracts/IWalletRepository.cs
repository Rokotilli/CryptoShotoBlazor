using DAL.Repositories.Pagination;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contracts
{
    public interface IWalletRepository : IGenericRepository<Wallet>
    {
        Task<Pagination<Wallet>> PagedWallets(int page);

        Task<Pagination<Wallet>> GetWalletsByUserIdPaginated(int page, int userid);

        Task<IEnumerable<Wallet>> GetWalletsByUserId(int userid);

        Task<int> GetIdByUserNameAndCoin(int userid, int coinid);

        Task<float> GetCountOfCoin(int userid, int coinid);
    }
}
