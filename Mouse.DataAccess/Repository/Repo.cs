using Microsoft.EntityFrameworkCore;
using Mouse.DataAccess.Data;
using Mouse.Models;
using System.Linq.Expressions;
namespace Mouse.DataAccess.Repository
{
    public class Repo<T> : IRepository<T> where T: class
     {
        private readonly MouseDbContext _db;
        internal DbSet<T> dbset;
        public Repo(MouseDbContext db)
        {
            _db=db;
            this.dbset= _db.Set<T>();
            //_db.Categs == dbSet; same shit

        }
        public void Add(T item)
        {
            dbset.Add(item);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbset;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbset;
            return query.ToList();
        }

        public void Remove(T item)
        {
           dbset.Remove(item);  
        }
    }
}
