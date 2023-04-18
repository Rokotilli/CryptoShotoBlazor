using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Pagination.Parameters
{
    public class WalletParameters : QueryStringParameters
    {
        public int? UserId { get; set; }
    }
}
