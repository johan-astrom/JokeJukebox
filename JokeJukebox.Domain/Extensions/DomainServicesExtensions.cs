using JokeJukebox.Domain.DataAccess;
using JokeJukebox.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JokeJukebox.Domain.Extensions
{
    public static class DomainServicesExtensions
    {
        public static IServiceCollection AddJokeJukeboxDomain(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<JokeJukeboxContext>(
                options => options.UseSqlServer(config.GetConnectionString("default")));
            services.AddScoped(typeof(IJokeJukeboxRepository<>), typeof(JokeJukeboxRepository<>));
            return services;
        }
    }
}
