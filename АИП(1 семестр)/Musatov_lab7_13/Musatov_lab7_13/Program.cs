using System;
/* Дано натуральное число N. Составить процедуру для поиска и вывода на
экран всех различных простых множителей заданного числа */
namespace Musatov_lab7_13
{
    class Program
    {
        static void prost(int N) {
            for (int i = N-1; i > 1; i--) 
            {
                if (N % i == 0)
                {
                    int count = 0;
                    for (int n = i; n > 0; n--) 
                    {
                        if (i % n == 0)
                        {
                            count++;
                        }
                    }
                    if (count == 2)
                    {
                        Console.Write("{0} ", i);
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            
            Console.Write("Введите число: ");
            int N = int.Parse(Console.ReadLine());
            Console.Write("Простые множители этого числа: ");
            prost(N);
        }
    }
}
