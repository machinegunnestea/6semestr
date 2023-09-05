using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        BinaryTree binaryTree = new BinaryTree();
        private const string FilePath = "identif.txt";
        private Hashtable Hashtable = new Hashtable();
        public Form1()
        {
            InitializeComponent();
        }
        //read from file button
        private void button1_Click(object sender, EventArgs e)
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
                dataGridView1.DataSource = Hashtable.Output();
            }
        }
        //search button
        private void button2_Click(object sender, EventArgs e)
        {
            var text = textBox1.Text;
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
                var index = dataGridView1.DataSource. .Cast<MyDictionary>().First(item => item.Value == text).Key;
                dataGridView1.TabIndex = index;

            }
        }
    }
}
