using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace def
{
    public class ContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
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
            var optionsBuilder =
                new DbContextOptionsBuilder<ApplicationContext>();
            DbContextOptions<ApplicationContext> options
                = optionsBuilder
                    .UseSqlServer(connectionString).Options;
            return new ApplicationContext(optionsBuilder.Options);


        }
    }
}
