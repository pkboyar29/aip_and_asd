using System;
using System.Collections.Generic;
using System.Text;

namespace kr_10_lab_11
{
    public class Punkti
    {
        public static int[] Raz(int[,] a)
        {
            int[] b = new int[a.GetLength(0)];
            int min = int.MaxValue;
            int max = int.MaxValue;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                min = int.MaxValue;
                max = int.MinValue;
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    if (min >= a[i, j])
                    {
                        min = a[i, j];
                    }
                    if (max <= a[i, j])
                    {
                        max = a[i, j];
                    }
                }
                b[i] = max - min;
            }
            return b;
        }
        public static int[] Diag(int[,] a)
        {
            int k = 0;
            for (int z = 0; z < a.GetLength(0); z++)
            {
                if (a[z, z] < 0)
                {
                    k++;
                }
            }
            int[] b = new int[k];
            int count = 0;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                int s = 0;
                if (a[i, i] < 0)
                {
                    for (int j = 0; j < a.GetLength(1); j++)
                    {
                        s += a[i, j];
                    }
                    b[count++] = s;
                }

            }
            if (k==0)
            {
                Array.Resize(ref b,b.Length+1);
                b[0] = -1;
            }
            return b;
        }
        public static int[] Pol(int[,] a)
        {
            int[] b = new int[a.GetLength(0)];
            int s = 0;
            int jj = -1;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                s = 0;
                jj = -1;
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    if (a[i, j] > 0)
                    {
                        jj = j;
                        break;
                    }
                }
                for (int z = jj + 1; z < a.GetLength(1); z++)
                {
                    s += a[i, z];
                }
                b[i] = s;
            }
            return b;
        }
        public static int[] Chet(int[,] a)
        {
            int[] b = new int[0];
            int k = 0;
            int count = 0;
            for (int j = 0; j < a.GetLength(1); j++)
            {
                k = 0;
                for (int i = 0; i < a.GetLength(0); i++)
                {
                    if (a[i, j] % 2 != 0)
                    {
                        k++;
                    }
                }
                if (k == a.GetLength(1))
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
