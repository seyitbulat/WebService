using Infrastructure.Model;
using System.Linq.Expressions;

namespace Infrastructure.DataAccess.Interfaces
{
    public interface IBaseRepository<TEntity>
        where TEntity : class, IEntity
    {
        List<TEntity> GetAll(Expression<Func<TEntity,bool>> predicate = null, params string[] includeList);
        TEntity Get(Expression<Func<TEntity,bool>> predicated, params string[] includeList);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
