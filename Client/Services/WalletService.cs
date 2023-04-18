using BLL.DTO;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Client.Services;

public class WalletService
{
    private readonly HttpClient httpClient;

    public WalletService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<IEnumerable<Coin>> GetAllCoins(int page)
    {
        return await httpClient.GetFromJsonAsync<IEnumerable<Coin>>($"api/coin/GetPagedCoins/{page}");
    }

    public async Task<IEnumerable<Coin>> GetAllCoinsWithoutPag()
    {
        return await httpClient.GetFromJsonAsync<IEnumerable<Coin>>($"api/coin");
    }

    public async Task<int> GetCountOfCoins()
    {
        var all = await httpClient.GetFromJsonAsync<IEnumerable<Coin>>("api/coin");

        if (all.Count() % 5 == 0)
            return all.Count() / 5;
        return all.Count() / 5 + 1;
    }

    public async Task<IEnumerable<Wallet>> GetAllUserCoins(int page, int userid)
    {
        var wallets = await httpClient.GetFromJsonAsync<IEnumerable<Wallet>>($"api/wallet/GetWalletsUser/{page}/{userid}");

        return wallets;
    }

    public async Task<int> GetCountOfUserCoins(int userid)
    {
        var all = await httpClient.GetFromJsonAsync<IEnumerable<Wallet>>($"api/wallet/GetWallets/{userid}");

        if (all.Count() % 5 == 0)
            return all.Count() / 5;
        return all.Count() / 5 + 1;
    }

    public async Task<bool> BuyCoin(WalletDTO wallet)
    {
        var result = await httpClient.PostAsJsonAsync("api/wallet", wallet);

        if (result.IsSuccessStatusCode)
            return true;
        return false;
    }

    public async Task BuyCoinCount(WalletDTO wallet)
    {
        wallet.Count += await CheckCountCoin(wallet.CoinId, wallet.UserId);
        var temp = await httpClient.GetFromJsonAsync<int>($"api/wallet/GetIdByUserNameAndCoin/{wallet.UserId}/{wallet.CoinId}");
        await httpClient.PutAsJsonAsync($"api/wallet/countcoin/{temp}", wallet);
    }

    public async Task<float> CheckCountCoin(int coinid, int userid)
    {
        return await httpClient.GetFromJsonAsync<float>($"api/wallet/CheckCountOfCoin/{coinid}/{userid}");
    }
}
