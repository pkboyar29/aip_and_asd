using System;
/*8)Дано натуральное число N. Написать рекурсивную функцию, вычислите
количество его цифр. При решении этой задачи нельзя использовать строки,
списки, массивы, циклы.*/
namespace lab1_8
{
    class Program
    {
        /// <summary>
        /// Вычисляет сумму цифр натурального числа n
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        static int Foo(int n)
        {
            if (n < 10)
            {
                return n;
            }
            int digit = n % 10;
            int nextN = n / 10;
            return digit + Foo(nextN); 
        }
        /// <summary>
        /// Вычисляет количество цифр натурального числа n
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        static int quant(int n)
        {
            if (n < 10)
            {
                return 1;
            }
            int nextN = n / 10;
            return 1 + quant(nextN);
        }
        static void Main(string[] args)
        {
            /*try
            {
                Console.Write("Введите натуральное число: ");
                string txt = Console.ReadLine();
                int N;
                if (!int.TryParse(txt, out N) || N <= 0)
                {
                    Console.WriteLine("Введено не натуральное число!");
                }
                else
                {
                    Console.WriteLine(Foo(N));
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }*/
            try
            {
                Console.Write("Введите натуральное число: ");
                string txt = Console.ReadLine();
                int N;
                if (!int.TryParse(txt, out N) || N <= 0)
                {
                    Console.WriteLine("Введено не натуральное число!");
                }
                else
                {
                    Console.WriteLine(quant(N));
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

        }
    }
}
