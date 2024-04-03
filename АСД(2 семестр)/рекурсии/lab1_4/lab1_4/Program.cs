using System;
/*Дано натуральное число N. Написать рекурсивную функцию, выводящую
все его цифры по одной, в обратном порядке, разделяя их пробелами или
новыми строками. При решении этой задачи нельзя использовать строки,
списки, массивы, циклы.
*/
namespace lab1_4
{
    class Program
    {
        /// <summary>
        /// Выводит все цифры числа N по одной, в обратном порядке, разделяя их пробелами
        /// </summary>
        /// <param name="N"></param>
        static void nums(int N)
        {
            if (N < 10)
            {
                Console.Write(N + " ");
            } else
            {
                int s = N % 10;
                int m = N / 10;
                Console.Write(s + " ");
                nums(m);
            }
            
        }
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Введите натуральное число N: ");
                string txt = Console.ReadLine();
                int N;
                if (int.TryParse(txt, out N) || N > 0)
                {
                    nums(N);
                } else
                {
                    Console.WriteLine("Введено не натуральное число!");
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }
    }
}
