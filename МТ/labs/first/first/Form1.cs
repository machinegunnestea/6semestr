// Разработал студент ИП-31 Коваленко Анастасия Игоревна. Дата рождения: 12.02.2003. Место рождения: город Витебск
using System;
using System.Windows.Forms;

namespace first
{
    public partial class Form1 : Form
    {
        public string alphabet; // алфавит языка
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            alphabet = textBox1.Text; //получаем данные о введенном алфавите
            string inputS = textBox2.Text; //получаем данные о введенной строке
            textBox3.Clear();
            try
            {
                if (alphabet == "") //проверка на пустое поле алфавита
                    throw new Exception("Поле ввода языка пустое");
                if (inputS == "") //проверка на пустое поле строки
                    throw new Exception("Поле ввода строки пустое");
                if (alphabet.Length > 33) //проверка на длину алфавита
                    throw new Exception("Вы превысили допустимую длину алфавита");
                if (inputS.Length > 20)//проверка на длину слова
                    throw new Exception("Вы превысили допустимую длину слова");
                else //проверка на принадлежность
                {
                    if (ChekingForTask1(alphabet, inputS)) textBox3.Text = "Принадлежит";//вызов функции проверки вхождения слова в алфавит
                    else textBox3.Text = "Не принадлежит";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Функция проверки вхождения слова в алфавит
        //alph - входной параметр функции, для работы со значением алфавита
        //str - входной параметр функции, для работы со значением строки
        static public bool ChekingForTask1(string alph, string str)
        {
            bool result = true; //переменная для передачи результата, true - принадлежит, false - не принадлежит
            //проверяет каждый символ из строки S для определения принадлежности к алфавиту
            for (int i = 0; i < str.Length; i++)
            {
                bool flag = false;
                for (int j = 0; j < alph.Length; j++)
                {
                    if (str[i] == alph[j]) flag = true;
                }
                if (flag == false) result = false;
            }
            return result;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        ///  Отработчик события при нажатии на chekBox "Все префиксы" для проверки принадлежности S алфавиту
        ///  Данная функция анализирует введенные алфавит и строку,  перебирает все варианты перфиксов в строки на префиксы
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            textBox5.Clear();
            string str = textBox4.Text;
            string result = null;
            textBox5.WordWrap = true;
            alphabet = textBox1.Text;

            try
            {
                if (alphabet == "")
                    throw new Exception("Поле ввода языка пустое");
                if (alphabet.Length > 40)
                    throw new Exception("Вы превысили допустимую длину языка");
                if (str.Length == 0)
                    throw new Exception("Поле ввода строки пустое");
                if(str.Length > 15)
                    throw new Exception("Вы превысили допустимую длину строки");
                else
                {
                    //// проверка принадлежности строки алфавиту
                    if (!ChekingForTask1(alphabet, str))
                        throw new Exception("Строка не принадлежит алфавиту языка");
                    else
                    {
                        ////делим строку на префиксы
                        int count = 1;
                        while (count<str.Length)
                        {
                            for (int i = 0; i <= count; i++)
                            {
                                result += str[i];
                            }
                            result += " ";
                            count++;
                        }
                        textBox5.Text = result;
                        label5.Text = "Все префиксы";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// Отработчик события при нажатии на chekBox "Все суффиксы" для проверки принадлежности S алфавиту
        /// Данная функция анализирует введенные алфавит и строку,  перебирает все варианты суффиксов строки
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox3.Checked = false;
            textBox5.Clear();
            string str = textBox4.Text;
            string result = null;
            textBox5.WordWrap = true;
            alphabet = textBox1.Text;

            try
            {
                if (alphabet == "")
                    throw new Exception("Поле ввода языка пустое");
                if (alphabet.Length > 40)
                    throw new Exception("Вы превысили допустимую длину языка");
                if (str.Length == 0)
                    throw new Exception("Поле ввода строки пустое");
                if (str.Length > 15)
                    throw new Exception("Вы превысили допустимую длину строки");
                else
                {
                    //// проверка принадлежности строки алфавиту
                    bool flag1 = false;
                    if (!ChekingForTask1(alphabet, str))
                        throw new Exception("Строка не принадлежит алфавиту языка");
                    else
                    {
                        int count = str.Length;
                        ////делим строку на суффиксы
                        while (count >=0)
                        {
                            for (int i = count; i < str.Length; i++)
                            {
                                result += str[i];
                            }
                            if (flag1)
                                result += " ";
                            count--;
                            flag1 = true;
                        }
                        textBox5.Text = result;
                        label5.Text = "Все суффиксы";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// Отработчик события при нажатии на chekBox "Все подстроки" для проверки принадлежности S алфавиту
        /// Данная функция анализирует введенные алфавит и строку, перебирает все варианты подстрок строки 
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            textBox5.Clear();
            string str = textBox4.Text;
            string result = null;
            textBox5.WordWrap = true;
            alphabet = textBox1.Text;
            try
            {
                if (alphabet == "")
                    throw new Exception("Поле ввода языка пустое");
                if (alphabet.Length > 40)
                    throw new Exception("Вы превысили допустимую длину языка");
                if (str.Length == 0)
                    throw new Exception("Поле ввода строки пустое");
                if (str.Length > 15)
                    throw new Exception("Вы превысили допустимую длину строки");
                else
                {
                    //// проверка принадлежности строки алфавиту
                    if (!ChekingForTask1(alphabet, str))
                        throw new Exception("Строка не принадлежит алфавиту языка");
                    else
                    {
                        string sttr = null;
                        bool flag = false;
                        ///циклы для перебора всех подстрок строки
                        for (int i = 0; i < str.Length; i++)
                        {
                            result += str[i];
                            result += " ";
                            sttr = str[i] + "";
                            for (int k = i+1; k < str.Length; k++)
                            {
                                if (k == str.Length - 1 && !flag)
                                    break;
                                sttr += str[k];
                                result += sttr;
                                result += " ";
                            }
                            flag = true;
                            sttr = null;

                        }
                        textBox5.Text = result;
                        label5.Text = "Все подстроки";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// Отработчик события при нажатии на кнопку "Определить" для определения вида подпоследовательности S2 в строке S1
        /// Данная функция анализирует введенные алфавит и строку, определяет виды подпоследовательностей 
        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            string str1 = textBox7.Text;
            string str2 = textBox6.Text;
            alphabet = textBox1.Text;

            try
            {
                // анализ строки
                if (alphabet == "")
                    throw new Exception("Поле ввода языка пустое");
                if (alphabet.Length > 40)
                    throw new Exception("Вы превысили допустимую длину языка");
                if (str1.Length == 0)
                    throw new Exception("Поле ввода строки S1 пустое");
                if (str1.Length > 15)
                    throw new Exception("Вы превысили допустимую длину строки S1");
                if (str2.Length == 0)
                    throw new Exception("Поле ввода строки S2 пустое");
                if (str2.Length > 15)
                    throw new Exception("Вы превысили допустимую длину строки S2");
                else
                {
                    // проверка принадлежности строк алфавиту
                    if (!ChekingForTask1(alphabet, str1))
                        throw new Exception("Строка S1 не принадлежит алфавиту языка");
                    if (!ChekingForTask1(alphabet, str2))
                        throw new Exception("Строка S2 не принадлежит алфавиту языка");
                    else if (str1.Length<str2.Length)
                    {
                        MessageBox.Show("Вторая строка не является подстрокой первой строки\n");
                        textBox7.Clear();
                        textBox6.Clear();

                    }
                    else
                    {
                        string result = null;
                        /// проверка, является ли S2 суффиксом
                        if (Syffix(str1, str2))
                            result += "Вторая подстрока S2 является суффиксом первой строки S1.\n";
                        /// проверка, является ли S2 префиксом
                        if (Prefix(str1, str2))
                            result = result + "Вторая подстрока S2 является префиксом первой строки S1.\n";
                        /// проверка, является ли S2 подстрокой
                        if (ContainsInStr(str1, str2))
                            result = result + "Вторая подстрока S2 является подстрокой первой строки S1.\n";

                        bool flag = false;
                        int j = 0;
                        /// цикл для проверки, является ли S2 подполедовательностью строки S1
                        for (int i = 0; i < str1.Length && j < str2.Length; i++)
                        {
                            if (str1[i] == str2[j])
                            {
                                flag = true;
                                j++;
                            }
                            else
                                flag = false;
                        }
                        if (!flag)
                            result = result + "Вторая подстрока S2 не является подпоследовательностью первой строки S1\n";
                        else
                            result = result + "Вторая подстрока S2  является подпоследовательностью первой строки S1\n";

                        richTextBox1.Text = result;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //функция проверки, является ли S2 суффиксом  S1
        public bool Syffix(string s1, string s2)
        {
            int j = s1.Length -1;
            bool flag = true;
            int count = s1.Length - 1;
            for (int i = s2.Length -1; i >=0; i--)
            {
                if (s1[j] != s2[i])
                    flag = false;
                j--;
            }
            return flag;
        }
        //функция проверки, является ли S2 префиксом  S1

        public bool Prefix(string s1, string s2)
        {
            bool flag = true;
            for (int i = 0; i < s2.Length; i++)
            {
                if (s1[i] != s2[i])
                    flag = false;
            }
            return flag;
        }

        /// функция проверки, является ли S2 подстрокой  S1
        public bool ContainsInStr(string s1, string s2)
        {
            if (s1.Contains(s2))
                return true;
            else
                return false;
        }
    }
}
