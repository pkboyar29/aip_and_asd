using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_3
{
    public class StupMas
    {
        public static void Output(int[][] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < a[i].Length; j++)
                    Console.Write("{0}\t", a[i][j]);
                Console.WriteLine();
            }
        }
        public static int[][] NewMas(int[,] a,int n,int N)
        {
            if (n<3)
                throw new Exception("Размерность не соответсвует условию");
            int [][] b = new int[n][];
            b[0] = Punkti.Bol(a, N);
            b[1] = Punkti.Sum(a, N);
            b[2] = Punkti.Nom(a, N);
            return b;
        }
    }
}
