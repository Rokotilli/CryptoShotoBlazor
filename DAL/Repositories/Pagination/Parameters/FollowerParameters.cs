using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Pagination.Parameters
{
    public class FollowerParameters: QueryStringParameters
    {
        public string? Name { get; set; }
    }
}
