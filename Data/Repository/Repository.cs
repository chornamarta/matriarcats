using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Data.Repository
{
    public class Repository<TEntity> where TEntity : class
    {
        private readonly DbContext dbContext;

        private readonly DbSet<TEntity> dbSet;

        public IEnumerable<TEntity> Find()
        {
            return dbSet.AsNoTracking().ToList();
        }

        public TEntity FindOne(Func<TEntity, bool> selector)
        {
            return dbSet.FirstOrDefault(selector);
        }

        public Repository(DbContext context)
        {
            dbContext = context;
            dbSet = context.Set<TEntity>();
        }
    }
}
