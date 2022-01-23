using Microsoft.EntityFrameworkCore;
using Northwind.Dal.Abstract;
using Northwind.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Dal.Concrete.EntityFramework.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : EntityBase
    {
        #region Variables
        protected DbContext context;
        protected DbSet<T> dbSet;
        #endregion

        #region Constructor
        public GenericRepository(DbContext context)
        {
            this.context = context;
            this.dbSet = this.context.Set<T>();
        }
        #endregion

        #region Methods
        public List<T> GetAll(params string[] includes)
        {
            IQueryable<T> data = dbSet;

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    data = data.Include(include);
                }
            }
            return data.ToList();
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> expression, params string[] includes)
        {
            IQueryable<T> data = dbSet;

            if (expression != null)
            {
                data = data.Where(expression);
            }

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    data = data.Include(include);
                }
            }

            return data;
        }

        public T Find(int id)
        {
            return dbSet.Find(id);
        }

        public T Find(Expression<Func<T, bool>> expression, params string[] includes)
        {
            IQueryable<T> data = dbSet;

            if (expression != null)
            {
                data = data.Where(expression);
            }

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    data = data.Include(include);
                }
            }

            return data.FirstOrDefault();
        }

        public T Add(T entity)
        {
            context.Entry(entity).State = EntityState.Added;
            dbSet.Add(entity);

            return entity;
        }

        public T Update(T entity)
        {
            dbSet.Update(entity);

            return entity;
        }

        public bool Delete(int id)
        {
            return Delete(Find(id));
        }

        public bool Delete(T entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                context.Attach(entity);
            }

            return dbSet.Remove(entity) != null;
        }

        public bool Any(Expression<Func<T, bool>> expression)
        {
            IQueryable<T> data = dbSet;

            if (expression != null)
            {
                data = data.Where(expression);
            }

            return data.Any();
        }
        #endregion
    }
}
