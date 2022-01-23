using Northwind.Entity.IBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Interface
{
    public interface IGenericService<T, TDto> where T : IEntityBase where TDto : IDtoBase
    {
        IResponse<List<TDto>> GetAll(params string[] includes);
        IResponse<List<TDto>> GetAll(Expression<Func<T, bool>> expression, params string[] includes);
        IResponse<TDto> Find(int id);
        IResponse<TDto> Find(Expression<Func<T, bool>> expression, params string[] includes);
        IResponse<IQueryable<T>> GetIQueryable();
        IResponse<TDto> Add(TDto item, bool hasTransactional = true);
        IResponse<Task<TDto>> AddAsync(TDto item);
        IResponse<TDto> Update(TDto item, bool hasTransactional);
        IResponse<Task<TDto>> UpdateAsync(TDto item);
        IResponse<bool> DeleteById(int id, bool hasTransactional = true);
        IResponse<Task<bool>> DeleteByIdAsync(int id);
        IResponse<bool> Delete(TDto item, bool hasTransactional = true);
        IResponse<Task<bool>> DeleteAsync(TDto item);
        bool Any(Expression<Func<T, bool>> expression);

        void SaveChanges();
    }
}
