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
    /// Логика взаимодействия для FindMovieType.xaml
    /// </summary>
    public partial class FindMovieType : Window
    {
        public static ListView FindMovieTypes;
        public FindMovieType()
        {
            InitializeComponent();
            FindMovieTypes = ViewFindMovieTypes;
        }
    }
}
