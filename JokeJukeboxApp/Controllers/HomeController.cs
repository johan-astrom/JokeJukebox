using JokeJukebox.App.Models;
using JokeJukeboxApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace JokeJukeboxApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _httpClient = new();
        private readonly string _url = "https://localhost:7055/api";

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(HomeViewModel viewModel)
        {
            return View(viewModel);
        }

        public async Task<IActionResult> SaveUserDetails(HomeViewModel viewModel)
        {
            var response = await _httpClient.PostAsJsonAsync(_url + "/authors", viewModel);
            var responseString = await response.Content.ReadAsStringAsync();
            dynamic dynamicObj = JsonConvert.DeserializeObject(responseString);
            long authorId = dynamicObj.id;
            var jokesViewModel = new JokesViewModel
            {
                SignedInUserId = authorId,
                SignedInUserName = viewModel.
                AuthorFirstName + " " + viewModel.AuthorLastName
            };
            return RedirectToAction("Index", "Jokes", jokesViewModel);   
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}