using System;
using System.Collections.Generic;
using System.Text;

namespace lab11_6
{
    class Matrix
    {
        //а) каждый элемент которого равен сумме элементов соответствующей строки;
        public static int[] SumOnLine(int[,] temp)
        {
            int n = temp.GetLength(0);
            int k = 0;
            int[] res = new int[n];
            for (int i = 0; i < n; i++)
            {
                int sum = 0;
                for (int j = 0; j < n; j++)
                {
                    sum += temp[i, j];
                }
                res[k++] = sum;
            }
            return res;
        }
        /* отрицательные элементы на побочной диагонали */
        public static int[] NegativeOnSide(int[,] temp)
        {
            int k = 0;
            int[] res = new int[0];
            for (int i = 0; i < temp.GetLength(0); i++)
            {
                for (int j = 0; j < temp.GetLength(1); j++)
                {
                    if (i == temp.GetLength(0) - j - 1 && temp[i, j] < 0)
                    {
                        Array.Resize(ref res, res.Length + 1);
                        res[k++] = temp[i, j];  
                    }
                }
            }
            return res;
        }
        /* в) каждый элемент которого равен значению первого по порядку
положительного элемента каждого столбца исходного массива и 1, если
положительные элементы в строке отсутствуют */
        public static int[] FirstPositive(int[,] temp)
        {
            int k = 0;
            int n = temp.GetLength(0);
            int[] res = new int[n];
            for (int i = 0; i < n; i++)
            {
                int quant = 0;
                for (int j = 0; j < n; j++)
                {
                    if (quant == 0 && temp[j, i] > 0)
                    {
                        quant++;
                        res[k++] = temp[j, i];
                    } else if (quant == 0 && j == n - 1)
                    {
                        res[k++] = 1;
                    }

                }
            }
            return res;
        }
        /*г) каждый элемент которого равен номерам строк, все элементы которых нули */
        public static int[] NumOfNulls(int[,] temp)
        {
            int k = 0;
            int n = temp.GetLength(0);
            int[] res = new int[0];
            for (int i = 0; i < n; i++)
            {
                int quant = 0;
                for (int j = 0; j < n; j++)
                {
                    if (temp[i, j] == 0)
                    {
                        quant++;
                    }
                }
                if (quant == n - 1)
                {
                    Array.Resize(ref res, res.l);
                }
            }
            return res;
        }
    }
}
