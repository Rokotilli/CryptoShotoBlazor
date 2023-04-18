using BLL.Contracts;
using DAL.Contracts;
using DAL.Models;
using DAL.Repositories;
using DAL.Repositories.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Managers
{
    public class NewsManager : INewsManager
    {
        public IUnitOfWork UnitOfWork { get; }

        public NewsManager(IUnitOfWork UnitOfWork)
        {
            this.UnitOfWork = UnitOfWork;
        }
        public async Task<News> GetLatestNew()
        {
            var model = await UnitOfWork.newsRepository.GetLatestNew();

            News temp = await UnitOfWork.newsRepository.GetByIdAsync(model);

            return temp;
        }

        public async Task<IEnumerable<News>> GetNewsAsync()
        {
            var model = await UnitOfWork.newsRepository.GetAllAsync();

            return model;
        }

        public async Task<Pagination<News>> GetPagedNews(int page)
        {
            var result = await UnitOfWork.newsRepository.PagedNews(page);

            return result;
        }
    }
}
