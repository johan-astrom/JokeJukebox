using JokeJukebox.Domain.Entities;
using System.Linq.Expressions;

namespace JokeJukebox.Domain.Repository
{
    public interface IJokeJukeboxRepository<TEntity> where TEntity : EntityBase
    {
        TEntity Add(TEntity entity);
        TEntity GetById(long id);
        IEnumerable<TEntity> Search(Expression<Func<TEntity, bool>> searchExpression);
        IEnumerable<TEntity> GetAll();
    }
}