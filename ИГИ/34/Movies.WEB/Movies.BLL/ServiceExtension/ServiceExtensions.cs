using Microsoft.Extensions.DependencyInjection;
using Movies.BLL.Services;
using Movies.DAL.Base;
using Movies.DAL.UnitsOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.BLL.ServiceExtension
{
    public static class ServiceExtensions
    {
        public static void AddUnitOfWorkContext(this IServiceCollection services, string dbConnection)
        {
            services.AddSingleton<IUnitOfWork, MovieCardDbUnitOfWork>(uow => new MovieCardDbUnitOfWork(dbConnection));
        }
        public static void AddProducerService(this IServiceCollection services)
        {
            services.AddSingleton<ProducerService>();
        }
        public static void AddScreenwriterService(this IServiceCollection services)
        {
            services.AddSingleton<ScreenwriterService>();
        }
        public static void AddMovieService(this IServiceCollection services)
        {
            services.AddSingleton<MovieService>();
        }
    }
}
