using BLL.Repositories;
using DAL.Models;
using BLL.Contracts;
using DAL.DBContext;

namespace BLL.Repositories;

public class CoinRepository : GenericRepository<Coin>, ICoinRepository
{
    public CoinRepository(CSContext databaseContext)
        : base(databaseContext)
    {
    }

}