using System;
/*Дана целочисленная матрица размера M  N. Найти номер последней из ее строк,
содержащих только четные числа. Если таких строк нет, то вывести 0. */
namespace Musatov_lab10_18
{
    class Program
    {
        static void Input(int[,] A)
        {
            Random rnd = new Random();
            for (int i = 0; i < A.GetLength(0); i++)
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    A[i, j] = rnd.Next(20);
                    // A[i, j] = int.Parse(Console.ReadLine());
                }

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
        static int prover(int[,] A)
        {
            int count = 0;
            int counta = -1;
            for (int i = 0; i < A.GetLength(0); i++)
            {
                count = 0;
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    if (A[i, j] % 2 == 0) 
                    {                               
                        count++;                    
                    }
                    
                }
                if (count == A.GetLength(1))
                {
                    counta = i;
                }
            }
            return counta;
        }
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Введите длину матрицы: ");
                int m = int.Parse(Console.ReadLine());
                Console.Write("Введите высоту матрицы: ");
                int n = int.Parse(Console.ReadLine());
                int[,] A = new int[n, m];
                Input(A);
                Output(A);
                if (prover(A) == -1)
                {
                    Console.WriteLine(0);
                }
                else
                {
                    Console.WriteLine("Номер последней строки, содержащей четные числа: {0}", prover(A) + 1);
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
