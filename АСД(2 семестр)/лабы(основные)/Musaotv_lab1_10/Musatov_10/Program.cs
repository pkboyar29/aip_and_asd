using System;
/* Кроме ряда Фибоначчи существует еще ряд Трибоначчи, который
начианется с тройки 0, 0, 1, а каждое следующее число равно сумме трёх
предыдущих. Числа нумеруются с 0. Напишите рекурсивную функцию,
возвращающую n-е число Трибоначчи. */

namespace Musatov_10
{
    class Program
    {
        /// <summary>
        /// Выводит n-е число Трибоначчи
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        static int trib(int n)
        {
            if (n < 0)
            {
                throw new Exception("Число не должно быть отрицательным!");
            }
            if (n == 0)
            {
                return 0;
            }
            if (n == 1)
            {
                return 0;
            }
            if (n == 2)
            {
                return 1;
            }
            else
            {
                return trib(n - 1) + trib(n - 2) + trib(n - 3);
            }
        }
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Введите число n: ");
                int n = int.Parse(Console.ReadLine());
                /*int N;
                int.TryParse(n, out N);*/
                Console.WriteLine(trib(n));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
