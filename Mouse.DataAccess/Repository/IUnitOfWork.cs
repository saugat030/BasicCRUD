﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mouse.DataAccess.Repository
{
    public interface IUnitOfWork
    {   ICategoryRepository Category{ get; }
        IProductRepository Product { get; }
        void Save();
    }
}
