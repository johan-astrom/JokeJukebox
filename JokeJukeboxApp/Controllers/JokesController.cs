using JokeJukebox.App.Models;
using JokeJukebox.Shared.DTO;
using JokeJukebox.Shared.Static;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace JokeJukebox.App.Controllers
{
    public class JokesController : Controller
    {
        private readonly HttpClient _httpClient = new();
        private readonly string _url = "https://localhost:7055/api";

        public IActionResult Index(JokesViewModel viewModel)
        {
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ShowRandomJoke(JokesViewModel viewModel)
        {
            string endpoint = viewModel.SelectedJokeCategory == JokeCategory.Any ? _url + "/jokes" : _url + "/jokes/" + (int) viewModel.SelectedJokeCategory;

            var response = await _httpClient.GetAsync(endpoint);
            var responseJson = await response.Content.ReadAsStringAsync();
            if (string.IsNullOrEmpty(responseJson))
            {
                viewModel.Joke = new JokeModel
                {
                    Witticism = "No jokes found! Add your own below.",
                    JokeCategory = "None",
                    Author = "None"
                };
            }
            else
            {
                viewModel.Joke = JsonConvert.DeserializeObject<JokeModel>(responseJson);
            }
            return View("Index", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddJoke(JokesViewModel viewModel)
        {
            var jokeData = new JokePostDto
            {
                Witticism = viewModel.NewJoke,
                AuthorId = viewModel.SignedInUserId
            };
            var result = await _httpClient.PostAsJsonAsync(_url + "/jokes", jokeData);
            viewModel.NewJoke = "";
            return View("Index", viewModel);
        }
    }
}
