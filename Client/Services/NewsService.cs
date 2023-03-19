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

    public async Task<IEnumerable<News>> GetNews()
    {

		return await httpClient.GetFromJsonAsync<IEnumerable<News>>("api/news");
	}
}
