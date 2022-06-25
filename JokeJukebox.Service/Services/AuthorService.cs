using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JokeJukebox.Domain.Entities;
using JokeJukebox.Domain.Repository;
using JokeJukebox.Domain.UnitsOfWork;
using JokeJukebox.Shared.DTO;

namespace JokeJukebox.Service.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IJokeJukeboxUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AuthorService(IJokeJukeboxUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public AuthorGetDto GetById(long id)
        {
            return _mapper.Map<AuthorGetDto>(_unitOfWork.AuthorRepository.GetById(id));
        }

        public AuthorGetDto CreateAuthor(AuthorPostDto authorData)
        {
            return _mapper.Map<AuthorGetDto>(_unitOfWork.AuthorRepository.Add(_mapper.Map<Author>(authorData)));
        }
    }
}
