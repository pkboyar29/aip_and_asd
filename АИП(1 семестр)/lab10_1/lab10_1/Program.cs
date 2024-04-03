using System;
/*Дана матрица размера MN и целое число K (1  K  M). Найти сумму и произведение
элементов K-й строки данной матрицы */
namespace lab10_1
{
    class Program
    {
        static void Input(int[,] A)
        {
            Random rnd = new Random();
            for (int i = 0; i < A.GetLength(0); i++)
                for (int j = 0; j < A.GetLength(1); j++)
                    A[i, j] = rnd.Next(1, 20);
        }
        static void Output(int[,] A)
        {
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                    Console.Write(" {0}", A[i, j]);
                Console.WriteLine();
            }
        }
        static int sum(int[,] A, int K)
        {
            K = K - 1;
            int sum = 0;
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    if (i == K)
                    {
                        sum += A[i, j];
                        
                    }
                }
            }
            return sum;
        }
        static int proizv(int[,] A, int K)
        {
            K = K - 1;
            int proizv = 1;
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    if (i == K)
                    {
                        proizv *= A[i, j];
                    }
                }
            }
            return proizv;
        }
        static void Main(string[] args)
        {
            Console.Write("Введите длину массива: ");
            int m = int.Parse(Console.ReadLine());
            Console.Write("Введите высоту массива: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Введите число K: ");
            int K = int.Parse(Console.ReadLine());
            int[,] A = new int[n, m];
            Input(A);
            Output(A);
            Console.WriteLine();
            Console.WriteLine("Сумма элементов K-й строки данной матрицы: {0}", sum(A, K));
            Console.WriteLine("Произведение элементов K-й строки данной матрицы: {0}", proizv(A, K));
        }
    }
}
