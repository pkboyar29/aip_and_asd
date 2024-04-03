using System;
using System.Collections.Generic;
using System.Text;

namespace kr_12_lab_11
{
    public class Matrix
    {
        public static void Input(int[,] a)
        {
            Random rnd = new Random();
            for (int i = 0; i< a.GetLength(0);i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    a[i, j] = rnd.Next(-20,20);
                }
            }
        }
        public static void Output(int[,] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write("{0}\t", a[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
