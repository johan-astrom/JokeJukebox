using JokeJukebox.Domain.Repository;
using JokeJukebox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JokeJukebox.Shared.DTO;
using AutoMapper;
using JokeJukebox.Domain.UnitsOfWork;
using JokeJukebox.Shared.Static;

namespace JokeJukebox.Service.Services
{
    public class JokeService : IJokeService
    {
        private readonly IJokeJukeboxUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public JokeService(IJokeJukeboxUnitOfWork unitOfWOrk, IMapper mapper)
        {
            _unitOfWork = unitOfWOrk;
            _mapper = mapper;
        }

        public JokeGetDto CreateJoke(JokePostDto jokeData)
        {
            var author = _unitOfWork.AuthorRepository.GetById(jokeData.AuthorId);
            var joke = _mapper.Map<Joke>(jokeData);
            joke.Author = author;
            joke.JokeCategory = EvaluateJokeCategory(joke.Witticism);
            return _mapper.Map<JokeGetDto>(_unitOfWork.JokeRepository.Add(joke));
        }

        private JokeCategory EvaluateJokeCategory(string witticism)
        {
            List<string> bellmanJokeStrings = new()
            {
                "bellman",
                "rysken",
                "tysken",
                "norsken",
                "torsken"
            };

            List<string> norwegianJokeStrings = new()
            {
                "norrmän",
                "norwegians"
            };

            if (witticism.ToLower().Contains("knock"))
            {
                return JokeCategory.KnockKnockJoke;
            }
            else if (bellmanJokeStrings.Any(bellmanString => witticism.ToLower().Contains(bellmanString)))
            {
                return JokeCategory.BellmanJoke;
            }
            else if (norwegianJokeStrings.Any(norwegianString => witticism.ToLower().Contains(norwegianString)))
            {
                return JokeCategory.NorwegianJoke;
            }
            else return JokeCategory.Other;
        }

        public JokeGetDto GetRandomJoke()
        {
            var jokes = _unitOfWork.JokeRepository.GetAll(j => j.Author);
            int randomIndex = ExtractRandomIndexFromList(jokes);
            return _mapper.Map<JokeGetDto>(jokes.ToList()[randomIndex]);
        }


        public JokeGetDto GetRandomJokeByCategory(int category)
        {
            var jokes = _unitOfWork.JokeRepository.Search(j => j.JokeCategory == (JokeCategory)category, j => j.Author);
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
