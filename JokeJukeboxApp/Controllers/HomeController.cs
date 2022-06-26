using JokeJukebox.App.Models;
using JokeJukeboxApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace JokeJukeboxApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(HomeViewModel viewModel)
        {
            return View(viewModel);
        }

        public IActionResult SaveUserDetails(HomeViewModel viewModel)
        {
            return RedirectToAction("Index");   
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}