﻿using BLL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Managers
{
    public class Manager : IManager
    {
        public IUnitOfWork UnitOfWork { get;}

        public Manager(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}