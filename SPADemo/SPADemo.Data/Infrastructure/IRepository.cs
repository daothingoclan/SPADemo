using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SPADemo.Data.Infrastructure
{
    public interface IRepository
    {
        void Add<T>(T enity) where T : class;

        void Update<T>(T entity) where T : class;

        void Delete<T>(T entity) where T: class;

        void Delete<T>(Expression<Func<T, bool>> where) where T : class;

        T GetById<T>(int id) where T : class;

        T Get<T>(Expression<Func<T, bool>> where) where T : class;

        IEnumerable<T> GetAll<T>() where T : class;

        IUnitOfWork CreateUnitOfWork();
    }
}
