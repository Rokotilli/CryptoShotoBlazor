using DAL.Models;
using DAL.Repositories.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Contracts
{
    public interface INewsManager
    {
        Task<IEnumerable<News>> GetNewsAsync();

        Task<News> GetLatestNew();

        Task<Pagination<News>> GetPagedNews(int page);
    }
}
