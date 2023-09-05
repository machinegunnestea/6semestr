using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ВLL.Extensions;

namespace WpfApp
{
    public static class ConfigureExtensions
    {
        public static void ConfigureUI(this IServiceCollection services, string connection)
        {
            services.ConfigureBLL(connection);
            services.AddTransient<View.MainWindow>();
        }

    }
}
