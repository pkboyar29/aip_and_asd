using System;
using System.Collections.Generic;
using System.Text;

namespace kr_2_zad_11_lab
{
    class StupMas
    {
        public static void Output(int[][] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < a[i].Length; j++)
                {
                    Console.Write("{0}\t", a[i][j]);
                }
                Console.WriteLine();
            }
        }
        public static int[][] NewMas (int [,] a,int n)
        {
            if (n < 4)
                throw new Exception ("Размерность не соответсвует условию");
            int[][] b = new int[n][];
            b[0] = Punkti.Diag(a);
            b[1] = Punkti.Pol(a);
            b[2] = Punkti.Otr(a);
            b[3] = Punkti.Mod(a);
            return b;
        }
    }
}
