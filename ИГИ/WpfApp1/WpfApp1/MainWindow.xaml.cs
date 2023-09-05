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

namespace UI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow1.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ListView AllUsers;
        public static ListView AllMovies;
        public static ListView AllMovieTypes;
        public MainWindow()
        {
            InitializeComponent();
            AllUsers = ViewAllUsers;
            AllMovies = ViewAllMovies;
            AllMovieTypes = ViewAllMovieTypes;

        }
    }
}
