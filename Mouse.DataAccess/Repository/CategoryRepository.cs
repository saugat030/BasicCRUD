using Mouse.DataAccess.Data;
using Mouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mouse.DataAccess.Repository
{
    public class CategoryRepository : Repo<Categ> , ICategoryRepository
    {
        private MouseDbContext _db;
        public CategoryRepository(MouseDbContext db):base(db)
        {
            _db = db;
        }

        public void Update(Categ obj)
        {
            _db.Categs.Update(obj);
        }
    }
}
