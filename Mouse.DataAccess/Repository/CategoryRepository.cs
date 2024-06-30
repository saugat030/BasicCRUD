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
        public CategoryRepository(MouseDbContext db):base(db) //The whole point of this is to just make an update method ,which is in the ICategory Repo idk why we inherit Repo<> tho.
        {
            _db = db;
        }

        public void Update(Categ obj)
        {
            _db.Categs.Update(obj);
        }
    }
}
