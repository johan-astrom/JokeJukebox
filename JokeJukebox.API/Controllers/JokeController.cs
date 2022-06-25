using JokeJukebox.Service.Services;
using JokeJukebox.Shared.DTO;
using Microsoft.AspNetCore.Mvc;

namespace JokeJukebox.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class JokesController : ControllerBase
    {
        private readonly IJokeService _service;

        public JokesController(IJokeService service)
        {
            _service = service;
        }

        [HttpGet]
        public JokeGetDto GetRandomJoke()
        {
            return _service.GetRandomJoke();
        }

        [HttpGet("{category}")]
        public JokeGetDto GetRandomJokeByCategory(int category)
        {
            return _service.GetRandomJokeByCategory(category);
        }

        [HttpPost]
        public JokeGetDto CreateJoke(JokePostDto jokeData)
        {
            return _service.CreateJoke(jokeData);
        }
    }
}
