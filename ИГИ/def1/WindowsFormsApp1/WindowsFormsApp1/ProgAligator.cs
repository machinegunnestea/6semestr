using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Data;
using WindowsFormsApp1.Entities;
using WindowsFormsApp1.Repositories;

namespace WindowsFormsApp1
{
    public partial class ProgAligator : Form
    {
        private IData data;
        public ProgAligator()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textBox1.Text;
                int height = Convert.ToInt32(textBox2.Text);
                int weight = Convert.ToInt32(textBox3.Text);
                dataGridView1.Rows.Clear();
                data.Aligator.Create(new Aligator(name, height, weight));
                Read(dataGridView1, data);
                dataGridView1.Refresh();
            }
            catch 
            {
                MessageBox.Show("Некорректный ввод");
            }
        }

        private void Read(DataGridView grid, IData data)
        {
            var alig = data.Aligator.GetAll();
            foreach (var item in alig)
            {
                grid.Rows.Add(item.Name, item.Height, item.Weight);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            int input = Convert.ToInt32(textBox4.Text);
            var obj = Search.FindByWeight(data.Aligator, Convert.ToInt32(textBox4.Text));
            if (obj != null)
                dataGridView2.Rows.Add(obj.Name, obj.Height, obj.Weight);
            else
                MessageBox.Show("Не найдено");
            dataGridView2.Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            {
                dataGridView1.Rows.Clear();
                data = JsonData.Get();
                Read(dataGridView1, data);
                dataGridView1.Refresh();
            }
            else
            {
                dataGridView1.Rows.Clear();
                data = MemoryData.Get();
                Read(dataGridView1, data);
                dataGridView1.Refresh();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            StringBuilder stringBuilder = new StringBuilder();
            var croc = data.Aligator.GetAll().GroupBy(x => x.Height).Select(g => new
            {
                Height = g.Key,
                AverageWidth = g.Average(x => x.Weight)
            });
            foreach (var item in croc)
            {
                stringBuilder.Append("Средний вес крокодилов равен " + item.AverageWidth + " для длины:" + item.Height + "\n");
            }
            richTextBox1.Text = stringBuilder.ToString();
        }
    }
}
