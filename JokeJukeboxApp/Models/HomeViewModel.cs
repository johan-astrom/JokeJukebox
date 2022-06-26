using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace JokeJukebox.App.Models
{
    public class HomeViewModel
    {
        public long AuthorId { get; set; }
        [Display(Name ="First name")]
        [JsonPropertyName("FirstName")]
        public string AuthorFirstName { get; set; }

        [Display(Name ="Last name")]
        [JsonPropertyName("LastName")]
        public string AuthorLastName { get; set; }

        [JsonPropertyName("Alias")]
        [Display(Name = "Alias")]
        public string AuthorAlias { get; set; }

        [Display(Name = "Show my real name on joke submission")]
        [JsonPropertyName("ShowRealName")]
        public bool ShowAuthorRealName { get; set; }
    }
}
