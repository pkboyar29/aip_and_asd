using System;
using System.Collections.Generic;
using System.Text;

namespace lab11_3_Musatov
{
    class InpOutp
    {
        public static void Input(int[,] A)
        {
            Random rnd = new Random();
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    //A[i, j] = rnd.Next(20);
                    A[i, j] = int.Parse(Console.ReadLine());
                }
            }
        }
        public static void Output(int[,] A)
        {
            Random rnd = new Random();
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    Console.Write("{0}\t", A[i, j]);
                }
                Console.WriteLine();
            }
        }
        public static void OutputRes(int[][] A)
        {
            for (int i = 0; i < A.Length; i++)
            {
                for (int j = 0; j < A[i].Length; j++)
                {
                    Console.Write("{0}  ", A[i][j]);
                }
                Console.WriteLine();
            }
        }
    }
}
