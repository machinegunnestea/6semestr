using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Hashtable
    {
        private const int Size = 100;

        private readonly string[] Data = new string[Size];
        private List<string> colisions = new List<string>();
        static public int indTable = 0;

        // число хэш-значений (входов хэш-таблицы). 

        private const int A = 5;

        public Hashtable()
        {
            for (int i = 0; i < Size; i++)
                colisions.Add("");
        }
        // модульный метод хэширования
        private int GetHash(string value)
        {
            // массив кодов символов строки
            var chars = value.ToCharArray();

            // сумма кодов юникода
            var h = 0;

            foreach (var c in chars)
            {
                h += c;
            }
            h = (h % Size);

            return h;
        }

        // разоешение колизий
        // value - квадрат числа (1,4,9...)
        private int SolveCollision(int index, int value)
        {
            var result = (index + value) % Size;

            return result;
        }

        public void Add(string value, bool clr = false)
        {
            var index = GetHash(value);
            int i = 1;
            if (Data[index] == null)
            {
                Data[index] = value;
                colisions[index] = ("отсуствует");

                indTable = index;
            }
            else
            {
                do
                {
                    index = SolveCollision(index, i * i);
                    colisions[index] = ("присуствует");
                    i++;
                }
                while (Data[index] != null);

                Data[index] = value;


                indTable = index;
            }
        }

        public long Find(string value)
        {
            var stopwatch = Stopwatch.StartNew();

            var index = GetHash(value);
            int i = 1;
            if (Data[index] == null)
            {
                return -1;
            }
            else if (Data[index] == value)
            {
                stopwatch.Stop();
                return stopwatch.ElapsedTicks;
            }
            else
            {
                while (Data[index] != value)
                {
                    index = SolveCollision(index, i * i);
                    i++;
                    if (Data[index] == null)
                    {
                        return -1;
                    }
                }
                stopwatch.Stop();
                return stopwatch.ElapsedTicks;
            }
        }

        public List<MyDictionary> Output()
        {
            var list = new List<MyDictionary>();

            for (var i = 0; i < Size; i++)
            {
                if (Data[i] == null)
                {
                    list.Add(new MyDictionary()
                    {
                        Key = i,
                        Value = string.Empty,
                    });
                }
                else
                {
                    list.Add(new MyDictionary()
                    {
                        Key = i,
                        Value = Data[i],
                        Colisions = colisions[i],
                    });
                }
            }

            return list;
        }

        public class MyDictionary
        {
            public int Key { get; set; }

            public string Value { get; set; }
            public string Colisions { get; set; }
        }
    }
}

