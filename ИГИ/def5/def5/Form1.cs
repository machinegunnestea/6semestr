using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace def5
{
    public partial class Form1 : Form
    {
        private readonly HttpClient client;
        public Form1()
        {
            InitializeComponent();
            this.client = new HttpClient();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            HttpResponseMessage response = await client.GetAsync($"https://localhost:5001/Api/Movie/8");
            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                richTextBox1.Text = result;
            }
            else
            {
                MessageBox.Show($"Ошибка {response.StatusCode}: {response.ReasonPhrase}");
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            HttpResponseMessage response = await client.DeleteAsync($"https://localhost:5001/Api/Actor/1");
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Объект успешно удален!");
                string resul = await response.Content.ReadAsStringAsync();
                richTextBox1.Text = resul;
            }
            else
            {
                MessageBox.Show($"Ошибка {response.StatusCode}: {response.ReasonPhrase}");
            }
        }
    }
}
