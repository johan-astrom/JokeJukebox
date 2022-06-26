using JokeJukebox.App.Models;
using Microsoft.AspNetCore.Mvc;

namespace JokeJukebox.App.Controllers
{
    public class JokesController : Controller
    {
        public IActionResult Index(JokesViewModel viewModel)
        {
            return View(viewModel);
        }
    }
}
