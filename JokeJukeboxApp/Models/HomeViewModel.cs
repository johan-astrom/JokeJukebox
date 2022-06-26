using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace JokeJukebox.App.Models
{
    public class HomeViewModel
    {
        public long AuthorId { get; set; }
        [Display(Name ="First name")]
        [JsonProperty(PropertyName = "FirstName")]
        public string AuthorFirstName { get; set; }

        [Display(Name ="Last name")]
        [JsonProperty(PropertyName = "LastName")]
        public string AuthorLastName { get; set; }

        [Display(Name = "Alias")]
        [JsonProperty(PropertyName = "Alias")]
        public string AuthorAlias { get; set; }

        [Display(Name = "Show my real name")]
        [JsonProperty(PropertyName = "ShowRealName")]
        public bool ShowAuthorRealName { get; set; }
    }
}
