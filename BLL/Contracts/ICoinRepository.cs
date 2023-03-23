using BLL.Repositories.Pagination.Parameters;
using BLL.Repositories.Pagination;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Contracts
{
    public interface ICoinRepository : IGenericRepository<Coin>
    {
        Task<Pagination<Coin>> PagedCoins(int page);
    }
}
