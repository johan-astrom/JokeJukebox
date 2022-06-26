using JokeJukebox.Shared.Static;

namespace JokeJukebox.App.Models
{
    public class JokesViewModel
    {
        public string Witticism { get; set; }
        public string JokeCategory { get; set; }
        public string JokeAuthor { get; set; }
        public string SignedInUserName { get; set; }
        public long SignedInUserId { get; set; }
        public JokeCategory SelectedJokeCategory { get; set; }
    }
}
