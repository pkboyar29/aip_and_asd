using System;
using System.Collections.Generic;
using System.Text;

namespace kr_6_lab_11
{
    public class Punkti
    {
        public static int[] Dich (int[,] a)
        {
            int s = 1;
            int k = 0;
            for (int z =0;z<a.GetLength(0);z++)
            {
                if (a[z, a.GetLength(0) - 1 - z]<0)
                {
                    k++;
                }
            }
            int[] b = new int[k];
            int count = 0;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                if (a[i, a.GetLength(0) - 1 - i] < 0)
                {
                    s = a[i, a.GetLength(0) - 1 - i];
                    for (int j = 0; j < a.GetLength(1); j++)
                    {
                        if (a[i, j] > 0)
                        {
                            s = s * a[i, j];
                        }

                    }
                    b[count] = s;
                    count++;
                }
            }
            if (b.Length==0)
            {
                Array.Resize(ref b, b.Length + 1);
                b[0] = 1;
            }
            return b;
        }
        public static int[] Sum(int[,] a)
        {
            int s = 0;
            int[] b = new int[a.GetLength(0)];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                s = 0;
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    s = s + a[i, j];
                }
                b[i] = s;
            }
            return b;
        }
        public static int[] Pol(int[,] a)
        {
            int[] b = new int[a.GetLength(1)];
            int k = 0;
            for (int j = 0; j <a.GetLength(1);j++)
            {
                for (int i = 0; i < a.GetLength(0); i++)
                {
                    if (a[i,j]>0)
                    {
                        b[j] = a[i, j];
                        break;
                    }
                }
                if(b[j]==0)
                {
                    b[j] = 1;
                }
            }
            return b;
        }
        public static int[] Nom(int[,] a)
        {
            int count = 0;
            int k = 0;
            int[] b = new int[0];;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                count = 0;
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    if (a[i, j] == 0)
                    {
                        count++;
                    }
                }
                if (count == a.GetLength(0))
                {
                    Array.Resize(ref b, b.Length + 1);
                    b[k++] = i;
                }    
            }
            if (b.Length ==0)
            {
                Array.Resize(ref b, b.Length + 1);
                b[0] = -1;
            }
            return b;
        }
    }
}
