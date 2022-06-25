using JokeJukebox.Domain.Repository;
using JokeJukebox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JokeJukebox.Shared.DTO;
using AutoMapper;

namespace JokeJukebox.Service.Services
{
    public class JokeService : IJokeService
    {
        private readonly IJokeJukeboxRepository<Joke> _repository;
        private readonly IMapper _mapper;

        public JokeService(IJokeJukeboxRepository<Joke> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public JokeGetDto CreateJoke(JokePostDto jokeData)
        {
            return _mapper.Map<JokeGetDto>(_repository.Add(_mapper.Map<Joke>(jokeData)));
        }

        public JokeGetDto GetRandomJoke()
        {
            var jokes = _repository.GetAll();
            int randomIndex = ExtractRandomIndexFromList(jokes);
            return _mapper.Map<JokeGetDto>(jokes.ToList()[randomIndex]);
        }


        public JokeGetDto GetRandomJokeByCategory(int category)
        {
            var jokes = _repository.Search(j => j.JokeCategory == (JokeCategory) category);
            int randomIndex = ExtractRandomIndexFromList(jokes);
            return _mapper.Map<JokeGetDto>(jokes.ToList()[randomIndex]);
        }

        private static int ExtractRandomIndexFromList(IEnumerable<Joke> jokes)
        {
            Random random = new();
            return random.Next(jokes.Count());
        }
    }
}
