using DAL.Context;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Extensions
{
    public static class ConfigureExtensions
    {
        public static void ConfigureDAL(this IServiceCollection services, string connection)
        {
            services.AddDbContext<MovieRentContext>(options => options.UseSqlServer(connection));
            services.AddScoped<IRepository<Movie>, MovieRepository>();
            services.AddScoped<IRepository<MovieType>, MovieTypeRepository>();
            services.AddScoped<IRepository<User>, UserRepository>();
            services.AddSingleton<IUnitOfWork, MovieRentDbUnitOfWork>(uow => new MovieRentDbUnitOfWork(connection));
        }
    }
}
