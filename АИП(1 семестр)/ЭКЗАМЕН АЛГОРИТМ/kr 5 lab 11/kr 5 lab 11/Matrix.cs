using System;
using System.Collections.Generic;
using System.Text;

namespace kr_5_lab_11
{
    public class Matrix
    {
        /// <summary>
        /// заполнение двумерного массива случайными числами
        /// </summary>
        /// <param name="temp"></param>
       public static void Input(int[,] temp)
        {
            Random rnd = new Random();
            for (int i = 0; i < temp.GetLength(0); i++)
                for (int j = 0; j < temp.GetLength(1); j++)
                    temp[i, j] = rnd.Next(-20, 20);

        }
        /// <summary>
        /// вывод двумерного массива в консоль
        /// </summary>
        /// <param name="temp"></param>
        public static void Output(int[,] temp)
        {
            for (int i = 0; i < temp.GetLength(0); i++)
            {
                for (int j = 0; j < temp.GetLength(1); j++)
                    Console.Write("{0}\t", temp[i, j]);
                Console.WriteLine();
            }
        }
    }
}
