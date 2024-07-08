using Mouse.DataAccess.Data;
using Mouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mouse.DataAccess.Repository
{
    internal class ProductRepository : Repo<Product>, IProductRepository
    {
        private readonly MouseDbContext _db;
        public ProductRepository(MouseDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Product obj)
        {
            _db.Products.Update(obj);
        }
    }
}
