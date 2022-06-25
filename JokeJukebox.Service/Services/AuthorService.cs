using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JokeJukebox.Domain.Entities;
using JokeJukebox.Domain.Repository;
using JokeJukebox.Shared.DTO;

namespace JokeJukebox.Service.Services
{
    public class AuthorService
    {
        private readonly IGenericRepository<Author> _repository;
        private readonly IMapper _mapper;

        public AuthorService(IGenericRepository<Author> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public AuthorGetDto CreateAuthor(AuthorPostDto authorData)
        {
            return _mapper.Map<AuthorGetDto>(_repository.Add(_mapper.Map<Author>(authorData)));
        }
    }
}
