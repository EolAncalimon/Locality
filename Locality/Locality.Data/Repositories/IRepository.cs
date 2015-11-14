using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Locality.Data.Repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> ListAll { get; }

        void Add(T entity);
        void Delete(T entity);
        void Delete(IEnumerable<T> entities);
        void Update(T entity);
        void Update(IEnumerable<T> entities);

        Task<T> Get(Expression<Func<T, bool>> where, bool tracking = true);
        
        IEnumerable<T> List(Expression<Func<T, bool>> where, bool tracking = true);

        Task SaveChangesAsync();

        bool Exists(T entity);
    }
}