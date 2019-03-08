using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        internal DbContext _context;

        public BaseRepository(DbContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Edit(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> query = _context.Set<T>().Where(predicate);
            return query;
        }

        public IEnumerable<T> GetAll()
        {
            IEnumerable<T> query = _context.Set<T>();
            return query;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
