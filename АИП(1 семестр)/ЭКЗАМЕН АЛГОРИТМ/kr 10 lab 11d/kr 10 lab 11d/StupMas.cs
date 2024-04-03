using System;
using System.Collections.Generic;
using System.Text;

namespace kr_10_lab_11d
{
   public class StupMas
    {
        public static int [][] NewMas (int [,] a,int n)
        {
            if (n < 4)
                throw new Exception("Неверная размерность массива");
            int[][] b = new int[n][];
            b[0] = Punkti.Raz(a);
            b[1] = Punkti.Diag(a);
            b[2] = Punkti.Pol(a);
            b[3] = Punkti.Chet(a);
            return b;
        }
        public static void Output (int [][] a)
        {
            for (int i =0; i< a.Length;i++)
            {
                for (int j = 0; j < a[i].Length; j++)
                {
                    Console.Write("{0}\t", a[i][j]);
                }
                Console.WriteLine();
            }
        }
    }
}
