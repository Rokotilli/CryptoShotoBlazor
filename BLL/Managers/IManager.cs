using BLL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Managers
{
    public interface IManager
    {
        public IUnitOfWork UnitOfWork { get; }
    }
}
