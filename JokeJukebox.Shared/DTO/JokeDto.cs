using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JokeJukebox.Shared.DTO
{
    public class JokeGetDto
    {
        public string Witticism { get; set; }
        public string JokeCategory { get; set; }
        public string Author { get; set; }
    }

    public class JokePostDto
    {
        public string Witticism { get; set; }
        public long AuthorId { get; set; }
    }
}
