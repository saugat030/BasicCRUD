using Mouse.DataAccess.Data;
using Mouse.Models;

namespace Mouse.DataAccess.Repository
{
    public class Repo<T> : IRepository<T> where T: class
     {
        private readonly MouseDbContext _db;
        public Repo(MouseDbContext db)
        {
            _db=db;
        }
        public void Add(T item)
        {
            
        }

        public T Get(System.Linq.Expressions.Expression<Func<T, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(T item)
        {
            throw new NotImplementedException();
        }
    }
}
