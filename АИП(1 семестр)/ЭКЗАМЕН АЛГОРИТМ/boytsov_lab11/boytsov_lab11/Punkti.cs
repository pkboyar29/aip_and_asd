using System;
using System.Collections.Generic;
using System.Text;

namespace boytsov_lab11
{
    public class Punkti
    {
        /// <summary>
        /// а) из элементов заданного массива, расположенных над главной диагональю;
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static int[] Diag(int[,] a)
        {
            int n = (a.Length - a.GetLength(0)) / 2;
            int[] b = new int[n];
            int k = 0;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    if (j > i)
                    {
                        b[k] = a[i, j];
                        k += 1;
                    }
                }
            }
            return b;
        }
        /// <summary>
        /// б) из элементов заданного массива, кратных трем.
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static int[] Krat(int[,] a)
        {
            int[] b = new int[0];
            int k = 0;
            string s = "";
            int S = 0;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                s = "";
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    int d = Math.Abs(a[i, j]);
                    s = "" + Math.Abs(a[i, j]);
                    int count = s.Length;
                    for (int z = 1; z <= count; z++)
                    {
                        int f = d % 10;
                        S = S + f;
                        d = d / 10;
                    }
                    if (S % 3 == 0 && S != 0)
                    {
                        Array.Resize(ref b, b.Length + 1);
                        b[k++] = a[i, j];
                    }
                    S = 0;
                }
            }
            return b;
        }
        /// <summary>
        /// в) каждый элемент которого равен сумме четных положительных элементов соответствующего столбца двумерного массива.
        /// </summary>
        /// <returns></returns>
        public static int[] ElStolb(int[,] a)
        {
            int s = 0;
            int[] b = new int[a.GetLength(1)];
            for (int j = 0; j < a.GetLength(1); j++)
            {
                s = 0;
                for (int i = 0; i < a.GetLength(0); i++)
                {
                    if (a[i, j] % 2 == 0 && a[i, j] > 0)
                    {
                        s = s + a[i, j];
                    }
                }
                b[j] = s;
            }
            return b;
        }
        /// <summary>
        /// г) каждый элемент которого равен наибольшему по модулю элементу соответствующего столбца двумерного массива. */
        /// </summary>
        /// <param name="a"></param>
        public static int[] MaxElStolb(int[,] a)
        {
            int z = 0;
            int k = 0;
            int[] b = new int[a.GetLength(1)];
            for (int j = 0; j < a.GetLength(1); j++)
            {
                int max = 0;
                for (int i = 0; i < a.GetLength(0); i++)
                {
                    if (Math.Abs(a[i, j]) > max)
                    {
                        max = Math.Abs(a[i, j]);
                        z = i;
                        k = j;
                    }
                }
                b[j] = a[z, k];
            }
            return b;
        }
    }
}
