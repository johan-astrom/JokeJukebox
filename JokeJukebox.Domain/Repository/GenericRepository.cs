using JokeJukebox.Domain.DataAccess;
using JokeJukebox.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JokeJukebox.Domain.Repository
{
    internal class GenericRepository<TEntity> where TEntity : EntityBase
    {
        private readonly JokeJukeboxContext _context;
        private readonly DbSet<TEntity> _set;

        public GenericRepository(JokeJukeboxContext context)
        {
            _context = context; 
            _set = _context.Set<TEntity>();
        }

        public TEntity Add(TEntity entity)
        {
            var createdEntity = _context.Add(entity);
            return createdEntity.Entity;
        }

        public TEntity GetById(long id)
        {
            return _set.FirstOrDefault(e => e.Id == id);
        }
    }
}
