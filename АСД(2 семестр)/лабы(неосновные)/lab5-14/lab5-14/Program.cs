using System;
using System.IO;
// Дан текстовый файл. Проанализировав в программе содержимое файла, выберите из него имена и занесите в очередь. Выведите содержимое очереди на экран и посчитайте количество элементов образованной очереди. 
namespace lab5_14
{
    class Program
    {
        /// <summary>
        /// выводит содержимое очереди на экран
        /// </summary>
        /// <param name="tmp">очередь, которую нужно вывести</param>
        static void Output(Queue<string> tmp)
        {
            foreach (string x in tmp)
            {
                Console.WriteLine($"{x} ");
            }

        }

        /// <summary>
        /// заполняет нашу очередь именами из текстового файла
        /// </summary>
        /// <param name="text">текстовый файл</param>
        /// <returns></returns>
        static Queue<string> Input(string text)
        {
            Queue<string> tmp = new Queue<string>();
            // создаём массив строк, в котором содержатся все слова файла, с помощью метода Split
            string[] arr = text.Split(' ');
            // создаём цикл, с помощью которого пройдёмся по каждому слову и запишем в очередь только имена
            int ident = 1;
            for (int i = 0; i < arr.Length; i++)
            {
                // записываем в строку a наше слово
                string a = arr[i];
                // проходим по слову и проверяем его на наличие различных символов, если они найдены, то ident не изменится, если найдено хоть что-то одно ненужное, то ident = 0
                for (int j = 0; j < a.Length; j++)
                {
                    // сама проверка, если символ является буквой, то ничего не происходит и всё хорошо, но если хотя бы один символ окажется не буквой, то ident станет равным 0
                    if (Char.IsLetter(a[j]))
                    {
                    } else
                    {
                        ident = 0;
                    }
                }
                // итак, если ident 1, то это значит, что всё по кайфу и мы записываем наше слово, которое состоит полностью из букв в очередь; если ident = 0, ничего не делаем по факту, нам оно не нужно
                if (ident == 1)
                {
                    tmp.Enqueue(a);
                } else if (ident == 0)
                {
                    ident = 1;
                }
            }
            return tmp;
        }
        static void Main(string[] args)
        {
            try
            {
                // наш путь к файлу (находится в bin/Debug/netcoreapp3.1 по умолчанию у меня, если ничего не указывать кроме названия файла)
                string path = "text.txt";
                // наш сам текстовый файл, с которым мы уже можем манипулировать в программе
                StreamReader reader = new StreamReader(path);
                // записываем из файла все содержимое в text
                string text = reader.ReadLine();
                Queue<string> s = Input(text);
                Output(s);
                Console.WriteLine("Количество элементов очереди: {0}", s.Count);
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
