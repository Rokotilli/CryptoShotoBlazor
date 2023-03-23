using DAL.Models;
using System.Collections.Generic;

namespace Client.Services;

public class NewsService
{
    private readonly HttpClient httpClient;

    public NewsService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<IEnumerable<News>> GetNews(int page)
    {
		return await httpClient.GetFromJsonAsync<IEnumerable<News>>($"api/news/GetPagedNews/{page}");
        
    }

    public async Task<News> GetLatestNew()
    {
        return await httpClient.GetFromJsonAsync<News>("api/news/GetLatestNew");
    }

    public async Task<int> GetCountOfNews()
    {
        var all = await httpClient.GetFromJsonAsync<IEnumerable<News>>("api/news");

        if(all.Count()%5 == 0)
            return all.Count()/5;
        return all.Count() / 5 + 1;
    }
}
