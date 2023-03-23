using BLL.Repositories;
using DAL.Models;
using BLL.Contracts;
using DAL.DBContext;
using BLL.Repositories.Pagination.Parameters;
using BLL.Repositories.Pagination;

namespace BLL.Repositories;

public class NewsRepository : GenericRepository<News>, INewsRepository
{
    public NewsRepository(CSContext databaseContext)
        : base(databaseContext)
    {
    }

    public async Task<int> GetLatestNew()
    {
        int newid = databaseContext.News.Max(u => u.Id);

        return newid;
    }

    public async Task<Pagination<News>> PagedNews(int page)
    {
        var news = databaseContext.News.AsEnumerable();

        var paged_list_news = await Pagination<News>.ToPagedListAsync(news, page);

        return paged_list_news;
    }
}