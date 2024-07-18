using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Mouse.DataAccess.Repository
{
    public interface IRepository<T> where T : class 
    {
        //T - Category or any other model we want to operate on.
        IEnumerable<T> GetAll(string? includeProperties = null);
        T Get(Expression<Func<T,bool>>filter, string? includeProperties = null);
        void Add(T item);
        void Remove(T item);
       // void Update(T item); eslai chai generic repository ma halindaina coz update ko logic might be  a bit complicated sometimes. So update is created whenever needed.

    }
}
