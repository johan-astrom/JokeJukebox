﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JokeJukebox.Domain.DataAccess
{
    internal class JokeJukeboxContext : DbContext
    {
        public JokeJukeboxContext(DbContextOptions options) : base(options)
        {
        }
        
    }
}
