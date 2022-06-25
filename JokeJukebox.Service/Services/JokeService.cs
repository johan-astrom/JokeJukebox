using JokeJukebox.Domain.Repository;
using JokeJukebox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JokeJukebox.Shared.DTO;

namespace JokeJukebox.Service.Services
{
    public class JokeService
    {
        private readonly IJokeJukeboxRepository<Joke> _repository;
        private readonly IMapper _mapper;

        public JokeService(IJokeJukeboxRepository<Joke> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public JokeGetDto GetRandomJoke()
        {
            var jokes = _repository.GetAll();
            Random random = new();
            var randomIndex = random.Next(jokes.Count());
            return _mapper.Map<JokeGetDto>(jokes.ToList()[randomIndex]);
        }
    }
}
