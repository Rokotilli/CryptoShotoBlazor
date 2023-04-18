using DAL.Models;
using DAL.Repositories.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Contracts
{
    public interface ICoinManager
    {
        Task<IEnumerable<Coin>> GetCoinsAsync();

        Task<Pagination<Coin>> GetPagedCoins(int page);
    }
}
