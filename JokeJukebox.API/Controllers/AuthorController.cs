using JokeJukebox.Service.Services;
using JokeJukebox.Shared.DTO;
using Microsoft.AspNetCore.Mvc;

namespace JokeJukebox.API.Controllers
{
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private IAuthorService _service;

        public AuthorController(IAuthorService service)
        {
            _service = service;
        }

        [HttpPost]
        public AuthorGetDto CreateAuthor(AuthorPostDto authorData)
        {
            return _service.CreateAuthor(authorData);
        }
    }
}
