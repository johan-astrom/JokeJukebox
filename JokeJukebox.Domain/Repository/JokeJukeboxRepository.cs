using JokeJukebox.Domain.DataAccess;
using JokeJukebox.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JokeJukebox.Domain.Repository
{
    public class JokeJukeboxRepository<TEntity> : IJokeJukeboxRepository<TEntity> where TEntity : EntityBase
    {
        private readonly JokeJukeboxContext _context;
        private readonly DbSet<TEntity> _set;

        public JokeJukeboxRepository(JokeJukeboxContext context)
        {
            _context = context;
            _set = _context.Set<TEntity>();
        }

        public TEntity Add(TEntity entity)
        {
            var createdEntity = _context.Add(entity);
            _context.SaveChanges();
            return createdEntity.Entity;
        }

        public TEntity GetById(long id)
        {
            return _set.FirstOrDefault(e => e.Id == id);
        }

        public TEntity GetById(long id, Expression<Func<TEntity, object>> includeExpression)
        {
            return _set.Include(includeExpression).FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<TEntity> Search(Expression<Func<TEntity, bool>> searchExpression, Expression<Func<TEntity, object>> includeExpression)
        {
            return _set.Include(includeExpression).Where(searchExpression);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _set;
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, object>> includeExpression)
        {
            return _set.Include(includeExpression);
        }
    }
}
