using JokeJukebox.Service.Services;
using JokeJukebox.Shared.DTO;
using Microsoft.AspNetCore.Mvc;

namespace JokeJukebox.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _service;

        public AuthorsController(IAuthorService service)
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
