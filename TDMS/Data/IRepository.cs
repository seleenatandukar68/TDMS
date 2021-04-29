using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TDMS.Data
{
    public interface IRepository<T> where T:  BaseEntity
    {
        Task<List<T>> GetAll();
        Task<T> Get(int id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(int id);

        Task<List<T>> GetAllByCondition(Expression<Func<T, bool>> condition);
    }
}
