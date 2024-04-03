using System;
using System.Collections.Generic;
using System.Text;

namespace kr_2_zad_11_lab
{
    class Punkti
    {
       public static int[] Diag(int[,] a)
        {
            int n = (a.Length - a.GetLength(0)) / 2;
            int[] b = new int[n];
            int count = 0;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j<i;j++)
                {
                    b[count] = a[i, j];
                    count++;
                }
            }
            return b;
        }
       public static int[] Pol(int[,] a)
        {
            int[] b = new int[0];
            int count = 0;
            int[] c = new int[0];
            int k = 0;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    if (a[i, j] > 0)
                    {
                        Array.Resize(ref b, b.Length + 1);
                        b[count] = a[i, j];
                        count++;
                    }
                    else
                    {
                        Array.Resize(ref c, c.Length + 1);
                        c[k] = a[i, j];
                        k++;
                    }
                }
            }
            return b;
        }
        public static int[] Otr(int[,] a)
        {
            int k = 0;
            int[] b = new int[a.GetLength(0)];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                k = 0;
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    if (a[i, j] % 2 != 0 && a[i, j] < 0)
                    {
                        k++;
                    }
                }
                b[i] = k;
            }
            return b;
        }
        public static int[] Mod(int[,] a)
        {
            int z = 0;
            int x = 0;
            int max = 0;
            int[] b = new int[a.GetLength(0)];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                max = 0;
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    if (Math.Abs(a[i, j]) > max)
                    {
                        max = Math.Abs(a[i, j]);
                        z = i;
                        x = j;
                    }
                }
                b[i] = a[z, x];
            }
            return b;
        }
    }
}
