using System;
using kr_2_zad_11_lab;

namespace Got_2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Введите размерность дмумерного массива N");
                int N = int.Parse(Console.ReadLine());
                int[,] a = new int[N, N];
                kr_2_zad_11_lab.Matrix.Input(a);
                kr_2_zad_11_lab.Matrix.Output(a);
                Console.WriteLine("");
                kr_2_zad_11_lab.StupMas.Output(StupMas.NewMas(a, 4));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }
    }
}
