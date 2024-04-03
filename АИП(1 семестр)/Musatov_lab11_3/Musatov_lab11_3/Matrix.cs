using System;
using System.Collections.Generic;
using System.Text;

namespace Musatov_lab11_3
{
    class Matrix
    {
        /* каждый элемент которого равен номерам строк, элементы которых
образуют монотонно возрастающую последовательность */
        public static int[] monot(int[,] temp)
        {
            int[] arr = new int[0];
            int a;
            int count;
            int k = 0;
            for (int i = 0; i < temp.GetLength(0); i++)
            {
                count = 0;
                a = int.MinValue;
                for (int j = 0; j < temp.GetLength(1); j++)
                {
                    if (temp[i, j] > a)
                    {
                        count++;
                        a = temp[i, j];
                    }
                }
                if (count == temp.GetLength(1))
                {
                    Array.Resize(ref arr, arr.Length + 1);
                    arr[k++] = i;
                }
            }
            return arr;
        }
        public static int[] EvenEl(int[,] a)
        {
            int[] temp = new int[0];
            int k = 0;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    if (a[i, j] % 2 == 0)
                    {
                        Array.Resize(ref temp, temp.Length + 1);
                        temp[k++] = a[i, j];

                    }
                }
            }
            return temp;
        }
        public static int[] MaxElColumn(int[,] temp)
        {
            int[] a = new int[temp.GetLength(1)];

            for (int j = 0; j < temp.GetLength(1); j++)
            {
                int max = temp[0, j];
                for (int i = 0; i < temp.GetLength(0); i++)
                {
                    if (temp[i, j] > max)
                        max = temp[i, j];
                }
                a[j] = max;
            }
            return a;

        }
        public static int[] Diag(int[,] temp)
        {
            int n = (temp.Length - temp.GetLength(0)) / 2 + temp.GetLength(0);
            int[] arr = new int[n];
            int k = 0;
            for (int i = 0; i < temp.GetLength(0); i++)
            {
                for (int j = 0; j < temp.GetLength(1); j++)
                {
                    if (j >= i)
                    {
                        arr[k++] = temp[i, j];
                    }
                }
            }
            return arr;
        }
    }
}
