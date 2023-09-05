using AutoMapper;
using DL.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.View;
using ВLL.Extensions;
using ВLL.Interfaces.EntityServices;
using ВLL.Services;

namespace UI
{
    public static class ConfigureExtensions
    {
        public static void ConfigureUI(this IServiceCollection services, string connection)
        {
            services.ConfigureBLL(connection);
            services.AddTransient<MainWindow>();
        }

    }
}
