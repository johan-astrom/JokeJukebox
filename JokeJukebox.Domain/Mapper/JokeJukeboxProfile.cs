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
            CreateMap<Joke, JokeGetDto>()
                .ForMember(dest => dest.Author, opt => opt.MapFrom(
                    src => src.Author.ShowRealName ? src.Author.FirstName + " " + src.Author.LastName : src.Author.Alias));
                
        }
    }
}
