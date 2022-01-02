using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Northwind.Dal.Abstract;
using Northwind.Dal.Concrete.EntityFramework.Repository;
using Northwind.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Dal.Concrete.EntityFramework.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        #region
        private DbContext _dbContext;
        private IDbContextTransaction _transaction;
        private bool _disposed = false;
        #endregion

        public UnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool BeginTransaction()
        {
            try
            {
                _transaction = _dbContext.Database.BeginTransaction();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Begin Transaction Error", ex);
            }
        }

        public bool RollBackTransaction()
        {
            try
            {
                _transaction.Rollback();
                _transaction = null;

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("RollBack Error", ex);
            }
        }

        public int SaveChanges()
        {
            var transaction = _transaction != null ? _transaction : _dbContext.Database.BeginTransaction();
            using (transaction)
            {
                try
                {
                    if (_dbContext == null)
                    {
                        throw new ArgumentException("Context was null");
                    }

                    var result = _dbContext.SaveChanges();

                    transaction.Commit();

                    return result;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception("SaveChanges Error", ex);
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IGenericRepository<T> GetRepository<T>() where T : EntityBase
        {
            return new GenericRepository<T>(_dbContext);
        }

        protected void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _transaction?.Dispose();
                    _dbContext?.Dispose();
                }
            }
            _disposed = true;
        }
    }
}
