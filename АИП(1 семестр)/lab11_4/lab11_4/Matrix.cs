using System;
using System.Collections.Generic;
using System.Text;

namespace lab11_4
{
    class Matrix
    {
        //а) каждый элемент которого равен количеству отрицательных элементов в соответствующей строке двумерного массива, кратных 3 или 7.
        public static int[] quantNegative(int[,] temp)
        {
            int n = temp.GetLength(0);
            int k = 0;
            int[] res = new int[n];
            for (int i = 0; i < n; i++)
            {
                int quant = 0;
                for (int j = 0; j < n; j++)
                {
                    if (temp[i, j] < 0 && (temp[i, j] % 7 == 0 || temp[i, j] % 3 == 0))
                    {
                        quant++;
                    }
                }
                res[k++] = quant;
            }
            return res;
        }
        //б) из элементов заданного массива, расположенных над побочной диагональю;
        public static int[] OverSideDiag(int[,] temp)
        {
            int n = (temp.Length - temp.GetLength(0)) / 2;
            int k = 0;
            int[] res = new int[n];
            for (int i = 0; i < temp.GetLength(0); i++)
            {
                for (int j = 0; j < temp.GetLength(1); j++)
                {
                    if (i < temp.GetLength(0) - j - 1)
                    {
                        res[k++] = temp[i, j];
                    }
                }
            }
            return res;
        }
        //в) каждый элемент которого равен первому четному элементу соответствующего столбца двумерного массива(если такого элемента в столбце нет, то он равен нулю).
        public static int[] FirstEven(int[,] temp)
        {
            int n = temp.GetLength(0);
            int k = 0;
            int[] res = new int[n];
            for (int i = 0; i < n; i++)
            {
                int ident = 0;
                int first = 0;
                for (int j = 0; j < n; j++)
                {
                    if (temp[j, i] % 2 == 0 && ident == 0)
                    {
                        first = temp[j, i];
                        ident = 1;
                    }
                }
                res[k++] = first;
            }
            return res;
        }
        //г)из отрицательных элементов исходного массива.
        public static int[] Negative(int[,] temp)
        {
            int n = temp.GetLength(0);
            int k = 0;
            int[] res = new int[0];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (temp[i, j] < 0)
                    {
                        Array.Resize(ref res, res.Length + 1);
                        res[k++] = temp[i, j];
                    }
                }
            }
            return res;
        }
    }
}
