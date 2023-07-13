using Infrastructure.DataAccess.Interfaces;
using Infrastructure.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.DataAccess.Implementations.EF
{
    public abstract class BaseRepository<TEntity, TContext> : IBaseRepository<TEntity>
        where TContext : DbContext, new()
        where TEntity : class, IEntity
    {
        public void Delete(TEntity entity)
        {
            using var ctx = new TContext();
            ctx.Set<TEntity>().Remove(entity);
            ctx.SaveChanges();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicated, params string[] includeList)
        {
            using var ctx = new TContext();
            IQueryable<TEntity> dbSet = ctx.Set<TEntity>(); 
            if(includeList.Length > 0)
            {
                foreach(var include in includeList)
                {
                    dbSet = dbSet.Include(include);
                }
            }
            return dbSet.Where(predicated).SingleOrDefault();
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null, params string[] includeList)
        {
            using var ctx = new TContext();
            IQueryable<TEntity> dbSet = ctx.Set<TEntity>();

            if(includeList.Length > 0)
            {
                foreach(var include in includeList)
                {
                    dbSet = dbSet.Include(include);
                }
            }

            if(predicate == null)
                return dbSet.ToList();

            return dbSet.Where(predicate).ToList();
        }

        public TEntity Insert(TEntity entity)
        {
            using var ctx = new TContext();
            ctx.Set<TEntity>().Add(entity);
            ctx.SaveChanges();
            return entity;
        }

        public void Update(TEntity entity)
        {
            using var ctx = new TContext();
            ctx.Set<TEntity>().Update(entity);
            ctx.SaveChanges();
        }
    }
}
