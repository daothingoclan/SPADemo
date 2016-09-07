using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SPADemo.Data.Infrastructure
{
    public class Repository : IRepository
    {
        private IDbFactory _dbFactory;
        private DbContext _context;

        public Repository(IDbFactory dbFactory)
        {
            _dbFactory = dbFactory;
            _context = _context ?? (_context = _dbFactory.Init());
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete<T>(Expression<Func<T, bool>> where) where T : class
        {
            IEnumerable<T> objects = _context.Set<T>().Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
                _context.Set<T>().Remove(obj);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Set<T>().Remove(entity);
        }

        public T Get<T>(Expression<Func<T, bool>> where) where T : class
        {
            return _context.Set<T>().Where<T>(where).FirstOrDefault();
        }

        public IEnumerable<T> GetAll<T>() where T : class
        {
            return _context.Set<T>().ToList();
        }

        public T GetById<T>(int id) where T : class
        {
            return _context.Set<T>().Find(id);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public IUnitOfWork CreateUnitOfWork()
        {
            return new UnitOfWork(_context);   
        }
    }
}
