using System;
/*Дано натуральное число N > 1. Написать рекурсивную функцию,
выводящая все простые множители этого числа в порядке неубывания с учетом
кратности.*/
namespace lab1_7
{
    class Program
    {
        /// <summary>
        /// выводит все простые множители этого числа в порядке неубывания с учетом кратности
        /// </summary>
        /// <param name="N"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        static void prime_factors(int N, int count) //count - это простой множитель (изначально при вызове функции всегда равен 2)
        {
            if (N <= 1)
            {
                return; // если число становится равным 1 или меньше, то необходимо закончить работу функции
            } else if (N % count == 0) // обычная проверка на простой множитель: если число делится на множитель без остатка, то это простой множитель этого числа
            {
                Console.Write("{0} ", count); // выводим это число
                prime_factors(N / count, count); // снова проверяем этот множитель, но только с числом N, разделённым на этот множитель
            } else // если простой множитель уже не подходит, то увеличиваем его на единицу и вызываем эту же рекурсивную функцию
            {
                prime_factors(N, count+1);
            }
        }
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Введите натуральное число: ");
                string txt = Console.ReadLine();
                int N;
                if (!int.TryParse(txt, out N) || N <= 1)
                {
                    Console.WriteLine("Введено не натуральное число!");
                }
                else
                {
                    prime_factors(N, 2);
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            // без рекурсии:
            /*int N = 180;
            for (int i = 2; i <= N;)
            {
                if (N % i == 0)
                {
                    Console.Write(i + " ");
                    N = N / i;
                } else
                {
                    i++;
                }
            }*/
            // единица не является простым числом
        }
    }
}
