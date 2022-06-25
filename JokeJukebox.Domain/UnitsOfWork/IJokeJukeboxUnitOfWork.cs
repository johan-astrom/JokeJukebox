using JokeJukebox.Domain.Entities;
using JokeJukebox.Domain.Repository;

namespace JokeJukebox.Domain.UnitsOfWork
{
    public interface IJokeJukeboxUnitOfWork
    {
        JokeJukeboxRepository<Author> AuthorRepository { get; }
        JokeJukeboxRepository<Joke> JokeRepository { get; }

        void Dispose();
        void Save();
    }
}