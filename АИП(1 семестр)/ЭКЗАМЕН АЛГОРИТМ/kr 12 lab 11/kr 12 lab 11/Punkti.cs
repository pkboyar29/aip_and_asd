using System;
using System.Collections.Generic;
using System.Text;

namespace kr_12_lab_11
{
    public class Punkti
    {
        public static int[] Naim(int[,] a)
        {
            int[] b = new int[a.GetLength(1)];
            int min = int.MaxValue;
            for (int j = 0; j < a.GetLength(1); j++)
            {
                min = int.MaxValue;
                for (int i = 0; i < a.GetLength(0); i++)
                {
                    if (a[i, j] <= min)
                    {
                        min = a[i, j];
                    }
                }
                b[j] = min;
            }
            return b;
        }
        public static int[] Diag(int[,] a, int K)
        {
            int k = 0;
            for (int z = 0; z < a.GetLength(0); z++)
            {
                if (a[z, a.GetLength(0) - 1 - z] > 0)
                {
                    k++;
                }
            }
            int[] b = new int[k];
            int count = 0;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                int s = 0;
                if (a[i, a.GetLength(0) - 1 - i] > 0)
                {
                    for (int j = 0; j < a.GetLength(1); j++)
                    {
                        if (a[i, j] > K)
                        {
                            s++;
                        }
                    }
                    b[count++] = s;
                }

            }
            if (k == 0)
            {
                Array.Resize(ref b, b.Length + 1);
                b[0] = -1;
            }
            return b;
        }
        public static int[] Chet(int[,] a)
        {
            int[] b = new int[a.GetLength(0)];
            int s = 0;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                s = 0;
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    if (a[i, j] % 2 != 0)
                    {
                        s += a[i, j];
                    }
                }
                b[i] = s;
            }
            return b;
        }
        public static int[] Nom(int[,] a)
        {
            int[] b = new int[0];
            int s = 0;
            int k = 0;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                k = 0;
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    if (a[i, j] > 0)
                    {
                        k++;
                    }
                }
                if (k == a.GetLength(0))
                {
                    Array.Resize(ref b, b.Length + 1);
                    b[s++] = i;
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
