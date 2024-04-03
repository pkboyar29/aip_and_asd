using System;
using System.Collections.Generic;
using System.Text;

namespace kr_5_lab_11
{
    public class Punkti
    {
        public static int[] Chet(int[,] a)
        {
            int k = 0;
            int[] b = new int[a.GetLength(0)];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                k = 0;
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    if (a[i, j] % 2 != 0)
                    {
                        k = a[i, j];
                    }
                }
                b[i] = k;
            }
            return b;
        }
        public static int[] Sum(int[,] a)
        {
            int k = 0;
            int s = 0;
            int[] b = new int[a.GetLength(1)];
            for (int j = 0; j < a.GetLength(1); j++)
            {
                k = 0;
                int f = 0;
                s = 0;
                for (int i = 0; i < a.GetLength(0); i++)
                {
                    int d = a[i, j];
                    f = d % 10;
                    d = d % 100;
                    d = d / 10;
                    if (((d * 2 + f) % 4 == 0 && a[i, j] > 0) || ((f == 0 || f == 5) && a[i, j] > 0))
                    {
                        s += a[i, j];
                    }
                }
                b[j] = s;
            }
            return b;
        }
        public static int[] Diag(int[,] a)
        {
            int n = (a.Length - a.GetLength(0)) / 2;
            int[] b = new int[n];
            int k = 0;
            for (int i = a.GetLength(0) -1; i > 0; i--)
            {
                for (int j = a.GetLength(0) - i; j < a.GetLength(0); j++)
                {
                    b[k] = a[i, j];
                    k += 1;
                }
            }
            return b;
        }
        public static int[] Chetn(int[,] a)
        {
            int k = 0;
            int[] b = new int[0];
            int count = 0;
            int[] c = new int[0];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    if (a[i, j] % 2 == 0 && a[i, j]!=0)
                    {
                        Array.Resize(ref b, b.Length + 1);
                        b[k++] = a[i, j];
                    }
                    else
                    {
                        Array.Resize(ref c, c.Length + 1);
                        c[count++] = a[i, j];
                    }
                }
            }
            return b;
        }
    }
}
