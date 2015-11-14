using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Locality.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly LocalityContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(LocalityContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public IEnumerable<T> ListAll { get; }
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void Delete(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Update(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                _context.Entry(entity).State = EntityState.Modified;
            }
        }

        public async Task<T> Get(Expression<Func<T, bool>> where, bool tracking = true)
        {
           var result = tracking
                    ? await _dbSet.Where(where).FirstOrDefaultAsync()
                    : await _dbSet.AsNoTracking().Where(where).FirstOrDefaultAsync();

            return result;
        }

        public IEnumerable<T> List(Expression<Func<T, bool>> where, bool tracking = true)
        {
            var result = tracking ? _dbSet.Where(where) : _dbSet.AsNoTracking().Where(where);

            return result;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public bool Exists(T entity)
        {
            return _dbSet.Local.Any(e => e == entity);
        }
    }
}