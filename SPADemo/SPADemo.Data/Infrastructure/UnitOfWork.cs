using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPADemo.Data.Infrastructure
{
    public class UnitOfWork : Disposable, IUnitOfWork
    {
        private DbContext _context;
        private DbContextTransaction _transaction;

        public UnitOfWork(DbContext context)
        {
            _context = context;
            _transaction = context.Database.BeginTransaction();
        }

        public void Commit()
        {
            _context.SaveChanges();
            _transaction.Commit();
        }

        public void Rollback()
        {
            _context.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
        }

        protected override void DisposeCore()
        {
            _transaction.Dispose();
            base.DisposeCore();
        }
    }
}
