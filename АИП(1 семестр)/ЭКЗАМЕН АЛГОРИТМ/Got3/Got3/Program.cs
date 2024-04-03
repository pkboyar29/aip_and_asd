using System;
using Lab_3;
namespace Got3
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Введите размерность двумерного массива");
                int n = int.Parse(Console.ReadLine());
                int[,] a = new int[n, n];
                Matrix.Input(a);
                Matrix.Output(a);
                Console.WriteLine("");
                StupMas.Output(StupMas.NewMas(a, 3, n));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
