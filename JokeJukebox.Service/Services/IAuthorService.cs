using JokeJukebox.Shared.DTO;

namespace JokeJukebox.Service.Services
{
    public interface IAuthorService
    {
        AuthorGetDto CreateAuthor(AuthorPostDto authorData);
    }
}