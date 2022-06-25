using AutoMapper;
using JokeJukebox.Shared.DTO;
using JokeJukebox.Domain.Entities;
using JokeJukebox.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JokeJukebox.Domain.Mapper
{
    public class JokeJukeboxProfile : Profile
    {
        public JokeJukeboxProfile()
        {
            CreateMap<AuthorPostDto, Author>();
            CreateMap<Author, AuthorGetDto>();

            CreateMap<JokePostDto, Joke>();
            CreateMap<Joke, JokeGetDto>();
        }
    }
}
