using System;
/*Дана последовательность, содержащая от 2 до 30 слов, в каждом из
которых от 2 до 10 латинских букв; между соседними словами -- не менее
одного пробела, за последним словом -- точка. Напечатать все слова,
отличные от последнего слова, предварительно преобразовав каждое из
них по следующему правилу: удалить из слова все последующие
вхождения первой буквы. */
namespace Musatov_lab13_33
{
    class Program
    {
        static string[] Remove(string s)
        {
            // удаляем точку в конце строки
            if (s[s.Length - 1] == '.')
            {
                s = s.Replace(".", ""); 
            }
            string[] wordsa = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string ss = "";
            // сравниваем слова с последним
            for (int i = 0; i < wordsa.Length; i++)
            {
                if (wordsa[i] != wordsa[wordsa.Length - 1] || i == wordsa.Length - 1)
                {
                    ss = ss + wordsa[i] + ' ';
                }
            }
            string[] words = ss.Split(' ');
            // проверяем количество слов (если меньше 2 или больше 30 - напоминаем об этом)
            if (words.Length > 30 || words.Length < 2)
            {
                Console.WriteLine("В последовательности меньше 2 или больше 30 слов!");
            } else
            {
                // предварительно изменяем слова по следующему правилу: удаляем из каждого все последующие вхождения первой буквы
                char m = ' ';
                for (int i = 0; i < words.Length; i++)
                {
                    for (int j = 0; j < words[i].Length; j++)
                    {
                        if (j == 0)
                        {
                            m = words[i][j];
                        }
                    }
                    char[] chararr = words[i].ToCharArray();
                    for (int z = 1; z < chararr.Length; z++)
                    {
                        if (chararr[z] == m)
                        {
                            chararr[z] = '*';
                        }
                    }
                    words[i] = new string(chararr);
                    words[i] = words[i].Replace("*", "");
                }
            }
            return words;
        }
        static void Output(string[] s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                Console.Write("{0} ", s[i]);
            }
        }
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Введите последовательность, содержащее от 2 до 30 слов, в каждом из которых от 2 до 10 латинских букв, между соседними словами не менее одного пробела, за последним словом точка: ");
                string txt = Console.ReadLine();
                string[] res = Remove(txt);
                Output(res);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}