using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using LFC.DAL.Contracts;

namespace LFC.DAL.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected LFCDbContext DataContext;
        public Repository(LFCDbContext dataContext)
        {
            DataContext = dataContext;
        }
        public async Task<List<TEntity>> FindAllAsync(
            Expression<Func<TEntity, bool>> expression, 
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return await GetValueWithInclude(includeProperties).Where(expression).ToListAsync();
        }

        public async Task<TEntity> FindEntityAsync(
            Expression<Func<TEntity, bool>> expression,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return await GetValueWithInclude(includeProperties).FirstOrDefaultAsync(expression);
        }

        public async Task CreateAsync(TEntity entity)
        {
            await DataContext.Set<TEntity>().AddAsync(entity);
        }

        public async Task Update(TEntity entity)
        {
            DataContext.Update(entity);
            await DataContext.SaveChangesAsync();
        }
        
        public async Task SaveChanges()
        {
            await DataContext.SaveChangesAsync();
        }

        public async Task Delete(TEntity entity)
        {
            DataContext.Set<TEntity>().Remove(entity);
            await DataContext.SaveChangesAsync();
        }
        
        private IQueryable<TEntity> GetValueWithInclude(
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> querriedEntities = DataContext.Set<TEntity>();

            return includeProperties.Aggregate(
                querriedEntities,
                (current, includeProperty) => current.Include(includeProperty));
        }
    }
}