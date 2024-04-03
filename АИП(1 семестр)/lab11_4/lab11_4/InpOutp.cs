using System;
using System.Collections.Generic;
using System.Text;

namespace lab11_4
{
    class InpOutp
    {
        public static void InputRnd(int[,] temp)
        {
            Random rnd = new Random();
            for (int i = 0; i < temp.GetLength(0); i++)
            {
                for (int j = 0; j < temp.GetLength(1); j++)
                {
                    temp[i, j] = rnd.Next(-10, 10);
                }
            }
        }
        public static void InputRL(int[,] temp)
        {
            for (int i = 0; i < temp.GetLength(0); i++)
            {
                for (int j = 0; j < temp.GetLength(1); j++)
                {
                    temp[i, j] = int.Parse(Console.ReadLine());
                }
            }
        }
        public static void Output(int[,] temp)
        {
            for (int i = 0; i < temp.GetLength(0); i++)
            {
                for (int j = 0; j < temp.GetLength(1); j++)
                {
                    Console.Write("{0}\t", temp[i, j]);
                }
                Console.WriteLine();
            }
        }
        public static void OutputRes(int[][] temp)
        {
            for (int i = 0; i < temp.Length; i++)
            {
                for (int j = 0; j < temp[i].Length; j++)
                {
                    Console.Write("{0}\t", temp[i][j]);
                }
                Console.WriteLine();
            }
        }
    }
}
