using BLL.Interfaces.EntityServices;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfApp.View;
using WpfApp.ViewModel;
using ВLL.Interfaces.EntityServices;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static ServiceProvider serviceProvider = ServiceProviderFactory.GetServiceProvider();
        public static DataManageVM context = new DataManageVM(serviceProvider.GetRequiredService<IMovieService>(), serviceProvider.GetRequiredService<IMovieTypeService>(), serviceProvider.GetRequiredService<IUserService>());
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
