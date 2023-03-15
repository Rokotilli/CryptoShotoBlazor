using BLL.Repositories;
using DAL.Models;
using BLL.Contracts;
using DAL.DBContext;

namespace BLL.Repositories;

public class WalletRepository : GenericRepository<Wallet>, IWalletRepository
{
    public WalletRepository(CSContext databaseContext)
        : base(databaseContext)
    {
    }

}