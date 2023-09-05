//taskTekst.Text = "7. Первый метод: таблица идентификаторов – бинарное дерево, обход Left-Right-Root." + 
//    "Второй метод: таблица идентификаторов – массив, полученный методом хеширования.Тип ключа – строка текста произвольной длины." +
//    " Преобразование строки – конкатенация битовых образов символов." +
//    " Метод хеширования – модульный.Метод разрешения коллизий – квадратичный.";
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using static WpfApp1.Hashtable;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BinaryTree binaryTree = new BinaryTree();
        private const string FilePath = "identif.txt";
        private Hashtable Hashtable = new Hashtable();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var text = name.Text;
            if (text == string.Empty)
            {
                MessageBox.Show("Введите имя идентификатора");
                return;
            }

            var first = Hashtable.Find(text);
            var stopwatch = Stopwatch.StartNew();

            var second = binaryTree.FindNode(text);
            var end = stopwatch.ElapsedTicks;

            var result = string.Empty;

            if (first > 0 && end > 0)
            {
                result = $"Результат поиска - идентификатор найден\r\nВремя поиска в хештаблице - {first}\r\nВремя поиска в дереве - {end}";
                if (first > end)
                {
                    result += "\nПоиск в хэштаблице занял больше времени";
                }
                else
                {
                    result += "\nПоиск в дереве занял больше времени";
                }
                var index = dataGrid.ItemsSource.Cast<MyDictionary>().First(item => item.Value == text).Key;
                dataGrid.SelectedIndex = index;
            }
            else
            {
                result = "Ничего не найдено";
            }



            MessageBox.Show(result);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var text = AddBlock.Text;
            if (text == string.Empty)
            {
                MessageBox.Show("Введите имя идентификатора");
                return;
            }
            
            if (Hashtable.Find(text) <= 0)
            {
                Hashtable.Add(text, true);
                binaryTree.Add(text);
            }
            else
            {
                MessageBox.Show("Введите уникальный идентификатор");
            }
            dataGrid.ItemsSource = Hashtable.Output();
            dataGrid.Columns[0].Width = 40;
            dataGrid.Columns[1].Width = 200;
            dataGrid.Columns[2].Width = 100;

            dataGrid.Columns[0].Header = "Индекс";
            dataGrid.Columns[1].Header = "Идентификатор";
            dataGrid.Columns[2].Header = "Коллизия";

            dataGrid.SelectedIndex = Hashtable.indTable;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            using (var reader = new StreamReader(FilePath))
            {

                string line;
                Hashtable = new Hashtable();
                binaryTree = new BinaryTree();
                while ((line = reader.ReadLine()) != null)
                {
                    Hashtable.Add(line);
                    binaryTree.Add(line);
                }
            }

            dataGrid.ItemsSource = Hashtable.Output();
            dataGrid.Columns[0].Width = 40;
            dataGrid.Columns[1].Width = 200;
            dataGrid.Columns[2].Width = 100;

            dataGrid.Columns[0].Header = "Индекс";
            dataGrid.Columns[1].Header = "Идентификатор";
            dataGrid.Columns[2].Header = "Колизия";
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
