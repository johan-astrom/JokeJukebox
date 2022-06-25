using JokeJukebox.Domain.Entities;
using System.Linq.Expressions;

namespace JokeJukebox.Domain.Repository
{
    internal interface IGenericRepository<TEntity> where TEntity : EntityBase
    {
        TEntity Add(TEntity entity);
        TEntity GetById(long id);
        IEnumerable<TEntity> Search(Expression<Func<TEntity, bool>> searchExpression);
    }
}