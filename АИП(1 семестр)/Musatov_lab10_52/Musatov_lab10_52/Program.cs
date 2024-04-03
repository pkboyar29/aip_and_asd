using System;
/*Дана квадратная матрица порядка M. Обнулить элементы матрицы, лежащие
одновременно выше главной диагонали и ниже побочной диагонали. Условный оператор
не использовать. */
namespace Musatov_lab10_52
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
        static void nul(int[,] A)
        {
            int N = A.GetLength(0);
            for (int i = 1; i < N / 2; i++)
                for (int j = N - i; j < N; j++)
                    A[i, j] = 0;

            for (int i = N / 2; i < N - 1; i++)
                for (int j = i + 1; j < N; j++)
                    A[i, j] = 0;
        }
        static void Main(string[] args)
        {
            Console.Write("Введите порядок квадратной матрицы: ");
            int M = int.Parse(Console.ReadLine());
            int[,] A = new int[M, M];
            Input(A);
            Output(A);
            nul(A);
            Console.WriteLine("Матрица после обнуления элементов одновременно выше главной диагонали и ниже побочной: ");
            Output(A);
            
        }
    }
}
