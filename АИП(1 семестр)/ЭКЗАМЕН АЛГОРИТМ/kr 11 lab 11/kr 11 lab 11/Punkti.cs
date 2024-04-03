using System;
using System.Collections.Generic;
using System.Text;

namespace kr_11_lab_11
{
    public class Punkti
    {
        public static int[] Diag(int[,] a)
        {
            int k = 0;
            int[] b = new int[0];
            int count = 0;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                int zz = -1;
                int s = 0;
                if (a[i, i] < 0)
                {
                    for (int z = 0; z < a.GetLength(1); z++)
                    {
                        if (a[i, z] < 0)
                        {
                            zz = z;
                            break;
                        }
                    }
                    if (zz != -1)
                    {
                        for (int j = 0; j < zz; j++)
                        {
                            s += a[i, j];
                        }
                        Array.Resize(ref b, b.Length + 1);
                        b[count++] = s;
                    }
                    else
                    {
                        Array.Resize(ref b, b.Length + 1);
                        b[count++] = 0;
                    }
                }
                else
                {
                    if (a[i, i] >= 0)
                    {
                        for (int j = 0; j < a.GetLength(1); j++)
                        {
                            if (a[i, j] > 0)
                            {
                                s += a[i, j];
                            }
                        }
                        if (s == 0)
                        {
                            Array.Resize(ref b, b.Length + 1);
                            b[count++] = 0;
                        }
                        Array.Resize(ref b, b.Length + 1);
                        b[count++] = s;
                    }
                }

            }
            return b;
        }
        public static int[] Kv(int[,] a)
        {
            int[] b = new int[a.GetLength(0)];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                int s = 1;
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    if (a[i, j] >= 1 && a[i, j] <= 10)
                    {
                        a[i, j] = (int)Math.Pow(a[i, j], 2);
                        s *= a[i, j];
                    }
                }
                b[i] = s;
            }
            return b;
        }
        public static int[] Kol(int[,] a)
        {
            int[] b = new int[a.GetLength(0)];
            int k = 0;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                k = 0;
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    if (a[i, j] < 0)
                    {
                        k++;
                    }
                }
                b[i] = k;
            }
            return b;
        }
        public static int[] Pos(int[,] a)
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
                        if (a[i, j] > a[i, j + 1])
                        {
                            k++;
                        }
                    }
                    else
                    {
                        if (j != a.GetLength(0) - 1)
                        {
                            if (a[i, j] > a[i, j + 1] && a[i, j] <= a[i, j - 1])
                            {
                                k++;
                            }
                        }
                    }
                }
                if (k == a.GetLength(0)-1)
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
