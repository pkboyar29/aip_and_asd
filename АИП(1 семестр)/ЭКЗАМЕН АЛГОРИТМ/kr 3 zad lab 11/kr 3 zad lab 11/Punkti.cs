using System;
using System.Collections.Generic;
using System.Text;

namespace kr_3_zad_lab_11
{
    public class Punkti
    {
        public static int[] Bol(int[,] a, int n)
        {
            int[] b = new int[a.GetLength(1)];
            int k = 0;
            for (int j = 0; j < a.GetLength(1); j++)
            {
                k = 0;
                for (int i = 0; i < a.GetLength(0); i++)
                {
                    if (a[i, j] > n)
                    {
                        k++;
                    }
                }
                b[j] = k;
            }
            return b;
        }
        public static int[] Nom(int[,] a, int n)
        {
            int[] b = new int[0];
            int k = 0;
            int ch = 0;
            int count = 0;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                ch = 0;
                k = 0;
                int c = a[i, 0];
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    if (c == a[i, j])
                    {
                        ch++;
                    }
                }
                if (ch == a.GetLength(0))
                {
                    Array.Resize(ref b, b.Length + 1);
                    k = i;
                    b[count++] = k;
                }
            }
            if (b.Length ==0)
            {
                Array.Resize(ref b, b.Length + 1);
                b[0] = -1;
            }
            return b;
        }
        public static int[] Sum(int[,] a, int n)
        {
            int[] b = new int[a.GetLength(0)];
            int k = 0;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                k = 0;
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    if (a[i, j] < n)
                    {
                        k = k + a[i, j];
                    }
                }
                b[i] = k;
            }
            return b;
        }
    }
}
