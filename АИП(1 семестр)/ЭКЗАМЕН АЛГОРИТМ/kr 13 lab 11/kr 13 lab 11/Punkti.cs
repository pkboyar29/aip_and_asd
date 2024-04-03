using System;
using System.Collections.Generic;
using System.Text;

namespace kr_13_lab_11
{
    public class Punkti
    {
        public static int[] Sum(int[,] a)
        {
            int[] b = new int[a.GetLength(0)];
            int min = int.MaxValue;
            int max = int.MinValue;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                min = int.MaxValue;
                max = int.MinValue;
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    if (a[i, j] <= min)
                    {
                        min = a[i, j];
                    }
                    if (a[i, j] >= max)
                    {
                        max = a[i, j];
                    }
                }
                b[i] = min + max;
            }
            return b;
        }
        public static int[] Diag(int[,] a)
        {
            int k = 0;
            int count = 0;
            for (int z = 0; z < a.GetLength(0); z++)
            {
                if (a[z, a.GetLength(0) - 1 - z] % 2 == 0)
                {
                    k++;
                }
            }
            int[] b = new int[k];
            for (int j = 0; j < a.GetLength(1); j++)
            {
                int s = 0;
                if (a[a.GetLength(0) - 1 - j, j] % 2 == 0)
                {
                    for (int i = 0; i < a.GetLength(0); i++)
                    {
                        if (a[i,j] >0)
                        {
                            s += a[i, j];
                        }
                    }
                    b[count++] = s;
                }
            }
            return b;
        }
        public static int[] kol(int[,] a)
        {
            int[] b = new int[a.GetLength(0)];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                int k = 0;
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    if (Math.Abs(a[i, j]) % 10 == 3 || Math.Abs(a[i, j]) % 10 == 5)
                    {
                        k++;
                    }
                }
                b[i] = k;
            }
            return b;
        }
        public static int[] Nom(int[,] a)
        {
            int[] b = new int[0];
            int count = 0;
            for (int j = 0; j < a.GetLength(1); j++)
            {
                int k = 0;
                for (int i = 0; i < a.GetLength(0); i++)
                {
                    int s = 0;
                    int d = a[i, j];
                    int f = 0;
                    string str = "" + d;
                    int kol = str.Length;
                    for (int z = 1; z <= kol; z++)
                    {
                        f = d % 10;
                        s += f;
                        d = d / 10;
                    }
                    if (s % 3 == 0 && s %3 !=0)
                    {
                        k++;
                    }
                }
                if (k == a.GetLength(0))
                {
                    Array.Resize(ref b, b.Length + 1);
                    b[count++] = j;
                }
            }
            if (b.Length == 0)
            {
                Array.Resize(ref b, b.Length + 1);
                b[0] = -1;
            }
            return b;
        }
    }

}
