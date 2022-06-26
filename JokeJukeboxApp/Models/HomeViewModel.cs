using System.ComponentModel.DataAnnotations;

namespace JokeJukebox.App.Models
{
    public class HomeViewModel
    {
        public long AuthorId { get; set; }
        [Display(Name ="First name")]
        public string AuthorFirstName { get; set; }
        [Display(Name ="Last name")]
        public string AuthorLastName { get; set; }
        [Display(Name = "Alias")]
        public string AuthorAlias { get; set; }
        [Display(Name = "Show my real name")]
        public bool ShowAuthorRealName { get; set; }
    }
}
