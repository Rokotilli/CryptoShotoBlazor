using BLL.Repositories;
using DAL.Models;
using BLL.Contracts;
using DAL.DBContext;
using BLL.Repositories.Pagination;
using Microsoft.EntityFrameworkCore;

namespace BLL.Repositories;

public class WalletRepository : GenericRepository<Wallet>, IWalletRepository
{
    public WalletRepository(CSContext databaseContext)
        : base(databaseContext)
    {
    }

    public async Task<Pagination<Wallet>> PagedWallets(int page)
    {
        var wallets = databaseContext.Wallets.AsEnumerable();

        var paged_list_news = await Pagination<Wallet>.ToPagedListAsync(wallets, page);

        return paged_list_news;
    }

    public async Task<IEnumerable<Wallet>> GetWalletsByUserId(int userid)
    {
        var wallets = databaseContext.Wallets.Where(w => w.UserId == userid).AsEnumerable();

        return wallets;
    }

    public async Task<Pagination<Wallet>> GetWalletsByUserIdPaginated(int page, int userid)
    {
        var wallets = databaseContext.Wallets.Where(w => w.UserId == userid).AsEnumerable();

        var paged_list_news = await Pagination<Wallet>.ToPagedListAsync(wallets, page);

        return paged_list_news;
    }

    public async Task<int> GetIdByUserNameAndCoin(int userid, int coinid)
    {
        var model = await databaseContext.Wallets.FirstOrDefaultAsync(w => w.UserId == userid && w.CoinId == coinid);

        return model.Id;
    }

    public async Task<float> GetCountOfCoin(int userid, int coinid)
    {
        var model = await databaseContext.Wallets.FirstOrDefaultAsync(w => w.UserId == userid && w.CoinId == coinid);

        return model.Count;
    }
}