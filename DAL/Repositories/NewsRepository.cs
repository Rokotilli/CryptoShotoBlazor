using DAL.Repositories;
using DAL.Models;
using DAL.Contracts;
using DAL.DBContext;
using DAL.Repositories.Pagination.Parameters;
using DAL.Repositories.Pagination;

namespace DAL.Repositories;

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