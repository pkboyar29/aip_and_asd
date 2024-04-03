using System;
using System.Collections.Generic;
using System.Text;

namespace kr_4_lab_11
{
    public class Punkti
    {
        public static int[] Kol(int[,] a)
        {
            int[] b = new int[a.GetLength(0)];
            int k = 0;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                k = 0;
                int S = 0;
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    int d = a[i, j];
                    string s = "" + a[i, j];
                    for (int z = 1; z <= s.Length; z++)
                    {
                        int f = d % 10;
                        S = S + f;
                        d = d / 10;

                    }
                    if ((S % 3 == 0 && S != 0 && a[i, j] < 0) || ((a[i,j] % 10 + (a[i,j] / 10) * 3) % 7 == 0 && a[i, j] < 0 && S % 3 != 0))
                    {
                        k++;
                    }
                    S = 0;
                }
                b[i] = k;
            }
            return b;
        }
        public static int[] Nad(int[,] a)
        {
            int n = (a.Length - a.GetLength(0)) / 2;
            int[] b = new int[n];
            int k = 0;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(0) - i - 1; j++)
                {
                    b[k++] = a[i, j];
                }
            }
            return b;
        }
        public static int[] Chet(int[,] a)
        {
            int[] b = new int[0];
            int k = 0;
            for (int j = 0; j < a.GetLength(1); j++)
            {
                for (int i = 0; i < a.GetLength(0); i++)
                {
                    if (a[i, j] % 2 == 0)
                    {
                        Array.Resize(ref b, b.Length + 1);
                        b[k++] = a[i, j];
                        break;
                    }
                }
            }
            if (b.Length == 0)
            {
                Array.Resize(ref b, b.Length + 1);
                b[0] = 0;
            }
            return b;
        }
        public static int[] Otr(int[,] a)
        {
            int[] b = new int[0];
            int k = 0;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    if (a[i, j] < 0)
                    {
                        Array.Resize(ref b, b.Length + 1);
                        b[k++] = a[i, j];
                    }
                }
            }
            return b;
        }
    }
}
