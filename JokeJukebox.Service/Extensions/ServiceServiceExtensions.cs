using JokeJukebox.Service.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JokeJukebox.Service.Extensions
{
    public static class ServiceServiceExtensions
    {
        public static IServiceCollection AddJokeJukeboxService(this IServiceCollection services)
        {
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IJokeService, JokeService>();
            return services;
        }
    }
}
