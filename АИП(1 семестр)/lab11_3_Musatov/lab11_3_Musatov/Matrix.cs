using System;
using System.Collections.Generic;
using System.Text;

namespace lab11_3_Musatov
{
    class Matrix
    {
        public static int[] quantEl(int[,] temp, int a)
        {
            int[] arr = new int[temp.GetLength(0)];
            int quant = 0;
            int k = 0;
            for (int j = 0; j < temp.GetLength(0); j++) 
            {
                for (int i = 0; i < temp.GetLength(1); i++)
                {
                    if (i == 0)
                        {
                            quant = 0;
                        }
                    if (temp[i, j] > a)
                    {
                        quant++;
                    }
                }
                arr[k++] = quant;
            }
            return arr;
        }
        public static int[] sumEl(int[,] temp, int a)
        {
            int[] arr = new int[temp.GetLength(1)];
            int sum = 0;
            int k = 0;
            for (int i = 0; i < temp.GetLength(0); i++)
            {
                for (int j = 0; j < temp.GetLength(1); j++)
                {
                    if (j == 0)
                    {
                        sum = 0;
                    }
                    if (temp[i, j] < a)
                    {
                        sum += temp[i, j];
                    }
                }
                arr[k++] = sum;
            }
            return arr;
        }
        public static int[] same(int[,] temp)
        {
            int[] arr = new int[0];
            int count = 0;
            int k = 0;
            int same = 0;
            for (int i = 0; i < temp.GetLength(0); i++)
            {
                for (int j = 0; j < temp.GetLength(1); j++)
                {
                    if (j == 0)
                    {
                        same = temp[i, j];
                    }
                    if (temp[i, j] == same)
                    {
                        count++;
                    }
                }
                if (count == temp.GetLength(1))
                {
                    Array.Resize(ref arr, arr.Length + 1);
                    arr[k++] = i;
                }
                count = 0;
            }
            return arr;
        }
    }
}
