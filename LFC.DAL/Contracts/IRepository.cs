using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LFC.DAL.Contracts
{
    public interface IRepository<TEntity>
    {
        Task<List<TEntity>> FindAllAsync(
            Expression<Func<TEntity, bool>> expression,
            params Expression<Func<TEntity, object>>[] includeProperties); 
        Task<TEntity> FindEntityAsync(
            Expression<Func<TEntity, bool>> expression,
            params Expression<Func<TEntity, object>>[] includeProperties);
        Task CreateAsync(TEntity entity);
        Task Update(TEntity entity);
        Task SaveChanges();
        Task Delete(TEntity entity);
    }
}