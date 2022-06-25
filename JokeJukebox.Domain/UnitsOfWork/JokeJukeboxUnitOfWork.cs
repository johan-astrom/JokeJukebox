using JokeJukebox.Domain.DataAccess;
using JokeJukebox.Domain.Entities;
using JokeJukebox.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JokeJukebox.Domain.UnitsOfWork
{
    public class JokeJukeboxUnitOfWork : IDisposable, IJokeJukeboxUnitOfWork
    {
        private JokeJukeboxContext _context;
        private JokeJukeboxRepository<Author> _authorRepository;
        private JokeJukeboxRepository<Joke> _jokeRepository;

        public JokeJukeboxRepository<Author> AuthorRepository
        {
            get
            {
                if (this._authorRepository == null)
                {
                    return new JokeJukeboxRepository<Author>(_context);
                }
                return this._authorRepository;
            }
        }

        public JokeJukeboxRepository<Joke> JokeRepository
        {
            get
            {
                if (this._jokeRepository == null)
                {
                    return new JokeJukeboxRepository<Joke>(_context);
                }
                return _jokeRepository;
            }
        }

        public JokeJukeboxUnitOfWork(JokeJukeboxContext context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


    }
}
