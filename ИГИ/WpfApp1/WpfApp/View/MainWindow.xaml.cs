using BLL.Interfaces.EntityServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp.ViewModel;
using ВLL.Interfaces.EntityServices;

namespace WpfApp.View
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private IMovieService _movieService;
        //private IMovieTypeService _movieTypeService;
        //private IUserService _userService;
        public static ListView AllUsers;
        public static ListView AllMovies;
        public static ListView AllMovieTypes;
        public MainWindow()
        {
             InitializeComponent();
            //DataContext = new DataManageVM(_movieService, _movieTypeService, _userService);
            AllUsers = ViewAllUsers;
            AllMovies = ViewAllMovies;
            AllMovieTypes = ViewAllMovieTypes;

        }
    }
}
