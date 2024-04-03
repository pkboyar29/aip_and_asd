using System;
using System.Collections.Generic;
using System.Text;

namespace _11_1
{
    class Matrix
    {
        //1)каждый элемент которого равен сумме четных положительных элементов соответствующего столбца двумерного массива.
        public static int[] Sum(int[,] temp)
        {
            int k = 0;
            int n = temp.GetLength(0);
            int[] res = new int[n];
            for (int i = 0; i < n; i++)
            {
                int sum = 0;
                for (int j = 0; j < n; j++)
                {
                    if (temp[j, i] > 0 && temp[j, i] % 2 == 0)
                    {
                        sum += temp[j, i];
                    }
                }
                res[k++] = sum;
            }
            return res;
        }
        //2)каждый элемент которого равен наибольшему по модулю элементу соответствующего столбца двумерного массива.
        public static int[] MaxModule(int[,] temp)
        {
            int k = 0;
            int n = temp.GetLength(0);
            int[] res = new int[n];
            for (int i = 0; i < n; i++)
            {
                int max = 0;
                for (int j = 0; j < n; j++)
                {
                    if (Math.Abs(temp[j, i]) > Math.Abs(max))
                    {
                        max = temp[j, i];
                    }
                }
                res[k++] = max;
            }
            return res;
        }
        //3)из элементов заданного массива, расположенных под главной диагональю;
        public static int[] UnderGlavDiag(int[,] temp)
        {
            int n = (temp.Length - temp.GetLength(0)) / 2;
            int k = 0;
            int[] res = new int[n];
            for (int i = 0; i < temp.GetLength(0); i++)
            {
                for (int j = 0; j < temp.GetLength(1); j++)
                {
                    if (i > j)
                    {
                        res[k++] = temp[i, j];
                    }
                }
            }
            return res;
        }
        //4)каждый элемент которого равен количеству нечетных отрицательных элементов соответствующей строки двумерного массива.
        public static int[] QuantOdd(int[,] temp)
        {
            int n = temp.GetLength(0);
            int k = 0;
            int[] res = new int[n];
            for (int i = 0; i < n; i++)
            {
                int quant = 0;
                for (int j = 0; j < n; j++)
                {
                    if (temp[i, j] < 0 && temp[i, j] % 2 != 0)
                    {
                        quant++;
                    }
                }
                res[k++] = quant;
            }
            return res;
        }
    }
}
