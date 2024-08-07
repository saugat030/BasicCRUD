//Ya chai aba we work with the datacontext ko kura haru.
using Microsoft.EntityFrameworkCore;
using Mouse.DataAccess.Data;
using Mouse.Models;
using System.Linq.Expressions;
namespace Mouse.DataAccess.Repository
{
    public class Repo<T> : IRepository<T> where T : class //This again gets inherited later by another repo of another model we want to work on.
    {
        private readonly MouseDbContext _db;
        internal DbSet<T> dbset;      //Just making a Dbset object since you cant do a _db.Dbset (We dont know the tye of the class ,It can me multiple tables sice 1 db set represents 1 table.)
        public Repo(MouseDbContext db) // This db comes from the constructor dependency injection in the controller.
        {
            _db = db;
            this.dbset = _db.Set<T>();
            //_db.Categs == dbSet; same shit yo pani alik imp kura xa. 
            _db.Products.Include(u => u.Category); //Foriegn Key category lai populate garna. EF ko smart way ho

        }
        public void Add(T item)
        {
            dbset.Add(item);
        }

        public T Get(Expression<Func<T, bool>> filter , string? includeProperties = null)
        {
            IQueryable<T> query = dbset;
            query = query.Where(filter);
            if (includeProperties != null)
            {
                foreach (var property in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property);

                }
            }
           
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll(string? includeProperties = null)
        {
            IQueryable<T> query = dbset;
            if (includeProperties != null)
            {
                foreach (var property in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property);

                }
            }
            return query.ToList();
        }

        public void Remove(T item)
        {
            dbset.Remove(item);
        }
    }
}
