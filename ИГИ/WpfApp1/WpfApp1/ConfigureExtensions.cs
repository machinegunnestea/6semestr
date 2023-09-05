using Microsoft.Extensions.DependencyInjection;
using WpfApp1;
using ВLL.Extensions;

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
