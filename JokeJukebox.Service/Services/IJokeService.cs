using JokeJukebox.Domain.Entities;
using JokeJukebox.Shared.DTO;

namespace JokeJukebox.Service.Services
{
    public interface IJokeService
    {
        JokeGetDto GetRandomJoke();
        JokeGetDto GetRandomJokeByCategory(int category);
        JokeGetDto CreateJoke(JokePostDto jokeData);
    }
}