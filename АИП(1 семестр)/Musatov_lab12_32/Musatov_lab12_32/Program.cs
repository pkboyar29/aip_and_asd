using System;
/*Дана строка, содержащая по крайней мере один символ пробела. Вывести
подстроку, расположенную между первым и вторым пробелом исходной
строки. Если строка содержит только один пробел, то вывести пустую
строку. */
namespace Musatov_lab12_32
{
    class Program
    {
        static string WhiteSpace(string s)
        {
            string res = "";
            string[] words = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int n = -1;
            int count = 0;
            string m = string.Join(s, words);
            while ((n = m.IndexOf(" ", n + 1)) >= 0)
            {
                count++;
            }
            if (count == 1)
            {
                res = "";
            } else
            {
                for (int i = 0; i < words.Length; i++)
                {
                    if (i == 1)
                    {
                        res = words[i];
                    }
                }
            }
            
            return res;
        }
        static void Main(string[] args)
        {
            Console.Write("Введите строку: ");
            string txt = Console.ReadLine();
            
            if (WhiteSpace(txt) == "")
            {
                Console.WriteLine("один пробел");
            } else
            {
                Console.WriteLine("Подстрока, расположенная между первым и вторым пробелом исходной строки: {0}", WhiteSpace(txt));
            }
        }
    }
}
