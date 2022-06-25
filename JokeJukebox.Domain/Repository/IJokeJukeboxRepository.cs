using JokeJukebox.Domain.Entities;
using System.Linq.Expressions;

namespace JokeJukebox.Domain.Repository
{
    public interface IJokeJukeboxRepository<TEntity> where TEntity : EntityBase
    {
        TEntity Add(TEntity entity);
        TEntity GetById(long id);
        TEntity GetById(long id, Expression<Func<TEntity, object>> includeExpression);
        IEnumerable<TEntity> Search(Expression<Func<TEntity, bool>> searchExpression, Expression<Func<TEntity, object>> includeExpression);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, object>> includeExpression);
    }
}