using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    public static class ServiceProviderFactory
    {
        private static ServiceProvider serviceProvider;
        public static ServiceProvider GetServiceProvider()
        {
            if (serviceProvider == null)
            {
                ServiceCollection services = new ServiceCollection();
                var builder = new ConfigurationBuilder();
                // установка пути к текущему каталогу
                builder.SetBasePath(Directory.GetCurrentDirectory());
                // получаем конфигурацию из файла appsettings.json
                builder.AddJsonFile("appsetting.json");
                // создаем конфигурацию
                var config = builder.Build();
                // получаем строку подключения
                string connectionString = config.GetConnectionString("DefaultConnection");
                ConfigureExtensions.ConfigureUI(services, connectionString);
                serviceProvider = services.BuildServiceProvider();
            }
            return serviceProvider;
        }
    }
}
