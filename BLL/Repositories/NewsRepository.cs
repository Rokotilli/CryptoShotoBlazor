using BLL.Repositories;
using DAL.Models;
using BLL.Contracts;
using DAL.DBContext;

namespace BLL.Repositories;

public class NewsRepository : GenericRepository<News>, INewsRepository
{
    public NewsRepository(CSContext databaseContext)
        : base(databaseContext)
    {
    }

}