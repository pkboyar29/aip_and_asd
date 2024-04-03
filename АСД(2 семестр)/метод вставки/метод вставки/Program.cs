using System;

namespace метод_вставки
{
    class Program
    {
        static void Input(int[] A)
        {
            Random rnd = new Random();
            for (int i = 0; i < A.Length; i++)
            {
                A[i] = rnd.Next(0, 20);
            }
        }
        static void Output(int[] A)
        {
            for (int i = 0; i < A.Length; i++)
            {
                Console.Write($"{A[i]}\t");
            }
        }
        static void Ins(int[] A)
        {
            int x, j;
            for (int i = 1; i < A.Length; i++) // начинаем с 1 индекса, а не с 0
            {
                x = A[i]; // x - это элемент, у которого индекс больше предыдущего на 1
                j = i - 1;
                while ((j >= 0) && (x < A[j]))
                {
                    A[j + 1] = A[j];
                    j = j - 1;
                }
                A[j + 1] = x;
            }
        }
        static void Main(string[] args)
        {
            int[] A = new int[5];
            Input(A);
            Output(A);
            Console.WriteLine();
            Console.WriteLine();
            Ins(A);
            Output(A);
        }
    }
}
