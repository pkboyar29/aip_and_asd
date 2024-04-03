﻿using System;
using System.Collections.Generic;
using System.Text;

namespace kr_4_lab_11
{
    public class StupMas
    {
        public static void Output(int [][] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < a[i].Length; j++)
                    Console.Write("{0}\t", a[i][j]);
                Console.WriteLine();
            }
        }
        public static int[][] NewMas(int[,] a, int n)
        {
            if (n < 4)
                throw new Exception("Неверная размерность массива");
            int[][] b = new int[n][];
            b[0] = Punkti.Kol(a);
            b[1] = Punkti.Nad(a);
            b[2] = Punkti.Chet(a);
            b[3] = Punkti.Otr(a);
            return b;
        }
    }
}
