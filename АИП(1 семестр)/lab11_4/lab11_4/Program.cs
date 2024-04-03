using System;

/*а) каждый элемент которого равен количеству отрицательных элементов в соответствующей строке двумерного массива, кратных 3 или 7.
б) из элементов заданного массива, расположенных над побочной диагональю;
в) каждый элемент которого равен первому четному элементу соответствующего столбца двумерного массива (если такого элемента в столбце нет, то он равен нулю).
г) из отрицательных элементов исходного массива. */
namespace lab11_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите порядок матрицы: ");
            int N = int.Parse(Console.ReadLine());
            int[,] arr = new int[N, N];
            InpOutp.InputRnd(arr);
            InpOutp.Output(arr);
            Console.WriteLine();
            int[][] res = new int[4][];
            res[0] = Matrix.quantNegative(arr);
            res[1] = Matrix.OverSideDiag(arr);
            res[2] = Matrix.FirstEven(arr);
            res[3] = Matrix.Negative(arr);
            InpOutp.OutputRes(res);

        }
    }
}
