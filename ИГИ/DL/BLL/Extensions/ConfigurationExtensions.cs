using AutoMapper;
using BLL.Interfaces.EntityServices;
using DL.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ВLL.Interfaces.EntityServices;
using ВLL.Profiles;
using ВLL.Services;

namespace ВLL.Extensions
{
    public static class ConfigurationExtensions
    {
        public static void ConfigureBLL(this IServiceCollection services, string connection)
        { 
            services.ConfigureDAL(connection);
            IMapper mapper = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new CarProfile());
                mc.AddProfile(new CarTypeProfile());
                mc.AddProfile(new UserProfile());

            }).CreateMapper();
            services.AddSingleton(mapper);
            services.AddTransient<ICarService, CarService>();
            services.AddTransient<ICarTypeService, CarTypeService>();
            services.AddTransient<IUserService, UserService>();

        }

    }
}
