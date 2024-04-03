using System;
using System.Collections.Generic;
using System.Text;

namespace kr_7_lab_11
{
    public class Punkti
    {
        public static int[] Pro(int[,] a)
        {
            int[] b = new int[a.GetLength(0)];
            int s = 1;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                s = 1;
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    s = s * a[i, j];
                }
                b[i] = s;
            }
            return b;
        }
        public static int[] Sum(int[,] a)
        {
            int[] b = new int[a.GetLength(0)];
            int min = 999;
            int max = 0;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                min = 999;
                max = 0;
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
                b[i] = min + max;
            }
            return b;
        }
        public static int[] SumStol(int[,] a)
        {
            int[] b = new int[a.GetLength(1)];
            int s = 0;
            int ii = -1;
            for (int j = 0; j < a.GetLength(1); j++)
            {
                s = 0;
                for (int i = 0; i < a.GetLength(0); i++)
                {
                    if (a[i, j] < 0)
                    {
                        ii = i;
                        break;
                    }
                }
                if (ii == -1)
                {
                    s = 100;
                }

                for (int z = ii + 1; z < a.GetLength(0); z++)
                {
                    s += a[z,j];
                }
                b[j] = s;
            }
            return b;
        }
        public static int[] Chet(int[,] a)
        {
            int[] b = new int[0];
            int s = -1;
            int k = 0;
            int count = 0;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                s = -1;
                k = 0;
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    if (a[i, j] % 2 == 0)
                    {
                        k++;
                    }
                }
                if (k == a.GetLength(0))
                {
                    s = i;
                    Array.Resize(ref b, b.Length + 1);
                    b[count++] = s;
                }
            }
            if (b.Length==0)
            {
                Array.Resize(ref b, b.Length + 1);
                b[0] = -1;
            }
            return b;
        }
    }
}
