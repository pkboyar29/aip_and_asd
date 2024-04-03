using System;
/* Дан массив размера N и целые числа K и L (1 ≤ K ≤ L ≤ N). Найти сумму и
произведение элементов массива с номерами от K до L включительно. */

namespace Musatov_lab8_16
{
    class Program
    {
        static void Input(int[] temp)
        {
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = int.Parse(Console.ReadLine());
                
            }
        }
        static void Output(int[] temp)
        {
            for (int i = 0; i < temp.Length; i++)
            {
                Console.Write("{0} ", temp[i]);
            }
        }
        static int SumArr(int[] temp, int K, int L)
        {
            int s = 0; 
            for (int i = 0; i < temp.Length; i++)
            {
                if (i == K)
                {
                    for (int m = K; m <= L ; m++)
                    {
                        s += temp[m];
                    }
                }
            }
            return s;
        }
        static int PrArr(int[] temp, int K, int L)
        {
            int s = 1;
            for (int i = 0; i < temp.Length; i++)
            {
                if (i == K)
                {
                    for (int m = K; m <= L; m++)
                    {
                        s *= temp[m];
                    }
                }
            }
            return s;
        }

        static void Main(string[] args)
        {
            try
            {
                Console.Write("Введите K: ");
                int K = int.Parse(Console.ReadLine());
                Console.Write("Введите L: ");
                int L = int.Parse(Console.ReadLine());
                Console.WriteLine();
                Console.Write("Введите N: ");
                int N = int.Parse(Console.ReadLine());
                if (1 <= K && K <= L && L <= N)
                {
                    int[] arr = new int[N];
                    Input(arr);
                    Console.WriteLine();
                    Output(arr);
                    Console.WriteLine();
                    Console.WriteLine("Сумма элементов массива с номерами от K до L включительно: {0}", SumArr(arr, K, L));
                    Console.WriteLine("Произведение элементов массива с номерами от K до L включительно: {0}", PrArr(arr, K, L));
                }
                else
                {
                    Console.WriteLine("1 <= K <= L <= M: данное условие не срабатывает");
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
