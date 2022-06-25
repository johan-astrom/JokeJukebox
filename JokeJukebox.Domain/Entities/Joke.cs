using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JokeJukebox.Domain.Entities
{
    public class Joke : EntityBase
    {
        public string Witticism { get; set; }
        public JokeCategory JokeCategory { get; set; }
        public Author Author { get; set; }  
    }
}
