using System;

namespace kr_5_lab_11
{
    public class StupMas
    {
        public static int[][] NewMassiv(int[,]a,int n)
        {
            if (n < 4)
                throw new Exception("Размерность не соответсвует условию");
            int[][] b = new int[n][];
            b[0] = Punkti.Chet(a);
            b[1] = Punkti.Sum(a);
            b[2] = Punkti.Diag(a);
            b[3] = Punkti.Chetn(a);
            return b;
        }
        /// <summary>
        /// Вывод ступенчятого массива
        /// </summary>
        /// <param name="a"></param>
        public static void Output(int[][] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < a[i].Length; j++)
                    Console.Write("{0}\t", a[i][j]);
                Console.WriteLine();
            }
        }
    }
}
