using DL.Context;
using DL.Entities;
using DL.Interfaces;
using DL.Repositories;
using DL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Extensions
{
    public static class ConfigureExtensions
    {
        public static void ConfigureDAL(this IServiceCollection services, string connection)
        {
            services.AddDbContext<AutoRentContext>(options => options.UseSqlServer(connection));
            services.AddScoped<IRepository<Car>, CarRepository>();
            services.AddScoped<IRepository<CarType>, CarTypeRepository>();
            services.AddScoped<IRepository<User>, UserRepository>();
            services.AddSingleton<IUnitOfWork, AutoRentDbUnitOfWork>(uow => new AutoRentDbUnitOfWork(connection));
        }
    }
}
