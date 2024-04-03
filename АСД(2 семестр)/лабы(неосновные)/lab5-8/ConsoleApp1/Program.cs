using System;
using System.IO;
// Дан текстовый файл. Проанализировав в программе содержимое файла, выберите из него числа и занесите в очередь. Выведите содержимое очереди на экран и посчитайте сумму этих чисел. 
namespace ConsoleApp1
{
    class Program
    {
        static void Output(Queue<int> tmp)
        {
            foreach (int x in tmp)
            {
                Console.Write($"{x} ");
            }

        }
        static Queue<int> Input(string text)
        {
            Queue<int> tmp = new Queue<int>();
            for (int i = 0; i < text.Length; i++)
            {
                if (Char.IsNumber(text[i]))
                {
                    tmp.Enqueue(text[i] - '0');
                }
            }
            return tmp;
        }
        static void Main(string[] args)
        {
            string path = "text.txt";
            StreamReader reader = new StreamReader(path);
            string text = reader.ReadToEnd();
            Queue<int> s = Input(text);
            Output(s);
        }
    }
}
