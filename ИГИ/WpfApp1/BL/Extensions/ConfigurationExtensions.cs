using AutoMapper;
using BLL.Interfaces.EntityServices;
using DAL.Extensions;
using Microsoft.Extensions.DependencyInjection;
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
                mc.AddProfile(new MovieProfile());
                mc.AddProfile(new MovieTypeProfile());
                mc.AddProfile(new UserProfile());

            }).CreateMapper();
            services.AddSingleton(mapper);
            services.AddTransient<IMovieService, MovieService>();
            services.AddTransient<IMovieTypeService, MovieTypeService>();
            services.AddTransient<IUserService, UserService>();

        }

    }
}
