using System;
using System.Collections.Generic;
using System.Text;

namespace kr_8_lab_11
{
    public class Punkti
    {
        public static int[] Naim(int[,] a)
        {
            int[] b = new int[a.GetLength(0)];
            int min = int.MaxValue;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                min = int.MaxValue;
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    if (min >= a[i, j])
                    {
                        b[i] = a[i, j];
                    }
                }
            }
            return b;
        }
        public static int[] Diag(int[,] a)
        {
            int k = 0;
            for (int z = 0; z < a.GetLength(0); z++)
            {
                if (a[z, z] > 0)
                {
                    k++;
                }
            }
            int[] b = new int[k];
            int count = 0;
            int max = 0;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                max = int.MinValue;
                if (a[i, i] > 0)
                {
                    for (int j = 0; j < a.GetLength(1); j++)
                    {
                        if (a[i, j] >= max)
                        {
                            max = a[i, j];
                        }
                    }
                    b[count++] = max;
                }

            }
            return b;
        }
        public static int[] Pred(int[,] a)
        {
            int[] b = new int[a.GetLength(1)];
            int ii = -1;
            int s = 0;
            for (int j = 0; j < a.GetLength(1); j++)
            {
                s = 0;
                ii = -1;
                for (int i = 0; i < a.GetLength(0); i++)
                {
                    if (a[i, j] < 0)
                    {
                        ii = i;
                        break;
                    }
                }
                if (ii != -1)
                {
                    for (int z = 0; z < ii; z++)
                    {
                        s += a[z, j];
                    }
                }
                else
                {
                    s = -1;
                }
                b[j] = s;
            }
            return b;
        }
        public static int[] Palind(int[,] a)
        {
            int[] b = new int[0];
            int count = 0;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                int k = 0;
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    string s = "" + a[i, j];
                    char[] ch = s.ToCharArray();
                    Array.Reverse(ch);
                    string S = new string(ch);
                    if (s == S)
                    {
                        k++;
                    }
                }
                if (k == a.GetLength(0))
                {
                    Array.Resize(ref b, b.Length+1);
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
