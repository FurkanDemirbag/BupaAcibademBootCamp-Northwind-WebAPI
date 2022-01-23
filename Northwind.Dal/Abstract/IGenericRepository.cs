using Northwind.Entity.IBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Dal.Abstract
{
    public interface IGenericRepository<T> where T : IEntityBase
    {
        List<T> GetAll(params string[] includes);
        IQueryable<T> GetAll(Expression<Func<T, bool>> expression, params string[] includes);
        T Find(int id);
        T Find(Expression<Func<T, bool>> expression, params string[] includes);
        T Add(T entity);
        T Update(T entity);
        bool Delete(int id);
        bool Delete(T entity);
        bool Any(Expression<Func<T, bool>> expression);

        //Include lu yapı gösterilecek
    }
}
