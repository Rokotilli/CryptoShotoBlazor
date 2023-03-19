using DAL.Models;

namespace CryptoBlazor.Services;

public class NewsService
{
    private readonly HttpClient httpClient;

    public NewsService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<IEnumerable<News>> GetNews()
    {
        return await httpClient.GetFromJsonAsync<IEnumerable<News>>("api/news");
    }
}