using Mouse.DataAccess.Data;
using Mouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mouse.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        
        private MouseDbContext _db;
        public ICategoryRepository Category { get; private set; }
        public UnitOfWork(MouseDbContext db)
            {
                _db = db;
            Category = new CategoryRepository(_db);
            }
            

        public void Save()
        {
           
            
            _db.SaveChanges();
           
        }
    }
}
