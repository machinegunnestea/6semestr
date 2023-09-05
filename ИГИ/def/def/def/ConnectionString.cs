using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace def
{
    public class ConnectionString
    {
        public static string ConnectString()
        {
            var builder = new ConfigurationBuilder();
            // установка пути к текущему каталогу
            builder.SetBasePath(Directory.GetCurrentDirectory());
            // получаем конфигурацию из файла appsettings.json
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            // получаем строку подключения
            string connectionString
                = config.GetConnectionString("DefaultConnection");
            return connectionString;
        }
    }
}
