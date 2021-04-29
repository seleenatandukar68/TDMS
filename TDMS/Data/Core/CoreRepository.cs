using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TDMS.Data.Core
{
    public  class CoreRepository<T> :IRepository<T>
       where T :  BaseEntity
       
    {
        protected readonly MyDbContext context;
        public CoreRepository(MyDbContext context)
        {
            this.context = context;
        }
        public async Task<T> Add(T entity)
        {
            context.Set<T>().Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Delete(int id)
        {
            var entity = await context.Set<T>().FindAsync(id);
            if (entity == null)
            {
                return entity;
            }

            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();

            return entity;
        }

        public async Task<T> Get(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetAll()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return entity;
        }
        public async Task<List<T>> GetAllByCondition(Expression<Func<T, bool>> condition)
        {
            return await context.Set<T>().Where(condition).ToListAsync();
        }
    }
}
