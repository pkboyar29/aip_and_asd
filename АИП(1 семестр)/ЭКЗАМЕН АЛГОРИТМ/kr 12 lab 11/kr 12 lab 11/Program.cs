﻿using System;

namespace kr_12_lab_11
{/*12. Дан двумерный массив размером N*N, заполненный целыми числами.
Сформировать ступенчатый массив, содержащий 4 строки, состоящие:
а) каждый элемент которого равен наименьшему элементу каждого столбца;
б) количество элементов которого равно количеству положительных
элементов на побочной диагонали исходной матрицы, а значения элементов
равны количеству элементов, значение которых больше заданного К в
каждой строки с положительным элементом на побочной диагонали.
в) каждый элемент которого равен сумме нечетных соответствующей строки
двумерного массива.
г) каждый элемент которого равен номерам строк, состоящих только из
положительных элементов
*/
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Введите размерность массива");
                int n = int.Parse(Console.ReadLine());
                int[,] a = new int[n, n];
                Matrix.Input(a);
                Matrix.Output(a);
                Console.WriteLine("");
                StupMas.Output(StupMas.NewMas(a, 4,n));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
