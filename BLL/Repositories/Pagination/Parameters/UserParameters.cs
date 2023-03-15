using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories.Pagination.Parameters
{
    public class UserParameters:QueryStringParameters
    {
        public string? Name { get; set; }

        public string? Email { get; set; }
    }
}
