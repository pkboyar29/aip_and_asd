using System;
/*Дано простое число N. Составить функцию, находящую следующее за N
простое число. Если входное данное не является простым числом, то
функция должна возвращать ноль */
namespace Musatov_lab7_18
{
    class Program
    {
        static bool prover(int n)
        {
            int count = 0;
            for (int i = n; i > 0; i--)
            {
                if (n % i == 0)
                {
                    count++;
                }
            }
            return count == 2;
        }
        static int sled(int n)
        {
            int j = 2;
            for (int i = n+1; j > 0; i++)
            {
                if (prover(i) == true)
                {
                    n = i;
                    j = 0;
                }
            }
            return n;
        }
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Введите простое число: ");
                int N = int.Parse(Console.ReadLine());
                if (prover(N) == true)
                {
                    Console.Write("Следующее простое число: {0}", sled(N));
                }
                else
                {
                    Console.WriteLine("0");
                }
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Out Range Error");
            }
            catch (FormatException)
            {
                Console.WriteLine("Format Error");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
