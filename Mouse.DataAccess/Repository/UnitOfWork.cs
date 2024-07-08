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
        public IProductRepository Product { get; private set; }
        public UnitOfWork(MouseDbContext db)  //yo classs ma chai db context lai matrai pass haneko ho. kun dbset ko ho doesnt matter here. Dbset chai paxi arkai ma define hunxa.
            {
                _db = db;
            Category = new CategoryRepository(_db);
            Product =  new ProductRepository(_db);
            }
            

        public void Save()
        {
           
            
            _db.SaveChanges();
           
        }
    }
}
