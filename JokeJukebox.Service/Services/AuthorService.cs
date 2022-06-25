using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JokeJukebox.Domain.Entities;
using JokeJukebox.Domain.Repository;

namespace JokeJukebox.Service.Services
{
    public class AuthorService
    {
        private readonly IGenericRepository<Author> _repository;

        public AuthorService(IGenericRepository<Author> repository)
        {
            _repository = repository;
        }

        public 
    }
}
