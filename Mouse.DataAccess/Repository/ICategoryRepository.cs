using Mouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mouse.DataAccess.Repository
{
    public  interface ICategoryRepository: IRepository<Categ>
    {
        void Update(Categ obj);
        
    }
}
