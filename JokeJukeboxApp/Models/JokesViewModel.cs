using JokeJukebox.Shared.Static;
using System.ComponentModel.DataAnnotations;

namespace JokeJukebox.App.Models
{
    public class JokesViewModel
    {
        public JokeModel Joke { get; set; }
        public string SignedInUserName { get; set; }
        public long SignedInUserId { get; set; }

        [Display(Name = "Select category (optional)")]
        public JokeCategory SelectedJokeCategory { get; set; }
    }
}
