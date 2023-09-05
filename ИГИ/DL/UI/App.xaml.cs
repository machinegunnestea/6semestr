using BLL.Interfaces.EntityServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using UI.View;
using UI.ViewModel;
using ВLL.Extensions;
using ВLL.Interfaces.EntityServices;
using ВLL.Services;

namespace UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        
        private static ServiceProvider serviceProvider= ServiceProviderFactory.GetServiceProvider();
        public static DataMangeVM context = new DataMangeVM(serviceProvider.GetRequiredService<ICarService>(), serviceProvider.GetRequiredService<ICarTypeService>(), serviceProvider.GetRequiredService<IUserService>());
        public App()
        {
            //serviceProvider=ServiceProviderFactory.GetServiceProvider();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow() { DataContext = context };
            MainWindow.Show();
            base.OnStartup(e); 
        }
       
    }
}
