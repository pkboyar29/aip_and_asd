using System;

//1)каждый элемент которого равен сумме четных положительных элементов соответствующего столбца двумерного массива. 
//2)каждый элемент которого равен наибольшему по модулю элементу соответствующего столбца двумерного массива. 
//3)из элементов заданного массива, расположенных под главной диагональю;
//4)каждый элемент которого равен количеству нечетных отрицательных элементов соответствующей строки двумерного массива. 
namespace _11_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите порядок матрицы: ");
            int N = int.Parse(Console.ReadLine());
            int[,] arr = new int[N, N];
            int[][] res = new int[4][];
            InpOutp.InputRnd(arr);
            InpOutp.Output(arr);
            Console.WriteLine();
            res[0] = Matrix.Sum(arr);
            res[1] = Matrix.MaxModule(arr);
            res[2] = Matrix.UnderGlavDiag(arr);
            res[3] = Matrix.QuantOdd(arr);
            InpOutp.OutputRes(res);
        }
    }
}
