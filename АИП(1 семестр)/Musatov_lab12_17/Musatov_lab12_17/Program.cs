using System;
/*Дана строка. Если она представляет собой запись целого числа, то
вывести 1, если вещественного (с дробной частью) — вывести 2; если
строку нельзя преобразовать в число, то вывести 0. Считать, что дробная
часть вещественного числа отделяется от его целой части десятичной
точкой «.». */
namespace Musatov_lab12_17
{
    class Program
    {
        static int prover(string s)
        {
            int num = 0;
            int count = 0;
            int dot = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (Char.IsNumber(s[i]) == true)
                {
                    count++;
                }
                if (s[i] == '.' && i != 0 && i != s.Length - 1)
                {
                    dot = 1;
                }
            }
            if (count == s.Length)
            {
                num = 1;
            }
            if (count == s.Length - 1 && dot == 1)
            {
                num = 2;
            }
            return num;

        }
        static void Main(string[] args)
        {
            Console.Write("Введите строку: ");
            string txt = Console.ReadLine();
            Console.WriteLine("{0}", prover(txt));
        }
    }
}
