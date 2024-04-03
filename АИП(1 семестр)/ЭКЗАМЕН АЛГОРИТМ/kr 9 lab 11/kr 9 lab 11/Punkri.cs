using System;
using System.Collections.Generic;
using System.Text;

namespace kr_9_lab_11
{
    public class Punkti
    {
        public static int[] Sr(int[,] a)
        {
            int[] b = new int[a.GetLength(0)];
            int s = 0;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                s = 0;
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    s += a[i, j];
                }
                b[i] = s / a.GetLength(0);
            }
            return b;
        }
        public static int[] Naib(int[,] a)
        {
            int[] b = new int[a.GetLength(0)];
            int max = int.MinValue;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                max = int.MinValue;
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    if (a[i, j] >= max)
                    {
                        max = a[i, j];
                    }
                }
                b[i] = max;
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
                for (int z = 0; z < jj; z++)
                {
                    s += a[i, z];
                }
                b[i] = s;
            }
            return b;
        }
        public static int[] Posled(int[,] a)
        {
            int[] b = new int[0];
            int k = 0;
            int count = 0;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                k = 0;
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    if (j == 0)
                    {
                        if (a[i, j] < a[i, j + 1])
                        {
                            k++;
                        }
                    }
                    else
                    {
                        if (j != a.GetLength(0) - 1)
                        {
                            if (a[i, j] < a[i, j + 1] && a[i, j] >= a[i, j - 1])
                            {
                                k++;
                            }
                        }
                    }
                }
                if (k == a.GetLength(0))
                {
                    Array.Resize(ref b, b.Length + 1);
                    b[count++] = i;
                }
                else
                {
                    Array.Resize(ref b, b.Length + 1);
                    b[count++] = -1;
                }
            }
            return b;
        }
    }
}
