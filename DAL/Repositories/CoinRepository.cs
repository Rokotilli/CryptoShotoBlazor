﻿using DAL.Repositories;
using DAL.Models;
using DAL.Contracts;
using DAL.DBContext;
using DAL.Repositories.Pagination;

namespace DAL.Repositories;

public class CoinRepository : GenericRepository<Coin>, ICoinRepository
{
    public CoinRepository(CSContext databaseContext)
        : base(databaseContext)
    {
    }

    public async Task<Pagination<Coin>> PagedCoins(int page)
    {
        var coins = databaseContext.Coins.AsEnumerable();

        var paged_list_news = await Pagination<Coin>.ToPagedListAsync(coins, page);

        return paged_list_news;
    }
}