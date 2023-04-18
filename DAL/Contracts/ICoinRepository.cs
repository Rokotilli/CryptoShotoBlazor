using DAL.Repositories.Pagination.Parameters;
using DAL.Repositories.Pagination;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contracts
{
    public interface ICoinRepository : IGenericRepository<Coin>
    {
        Task<Pagination<Coin>> PagedCoins(int page);
    }
}
