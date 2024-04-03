using System;

/* 3. Дан двумерный массив размером N*N, заполненный целыми числами.
Сформировать ступенчатый массив, содержащий 4 строки, состоящие:
а) каждый элемент которого равен количеству элементов соответствующего
столбца двумерного массива, больших данного числа.
б) каждый элемент которого равен сумме элементов соответствующей строки
двумерного массива, меньших данного числа.
в) каждый элемент которого равен номеру строки, в которой все элементы
одинаковы */

namespace lab11_3_Musatov
{
    class Program
    {
        
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Введите некоторое число: ");
                int l = int.Parse(Console.ReadLine());
                Console.Write("Введите порядок матрицы: ");
                int N = int.Parse(Console.ReadLine());
                int[,] a = new int[N, N];
                InpOutp.Input(a);
                InpOutp.Output(a);
                int[][] b = new int[3][];
                b[0] = Matrix.quantEl(a, l);
                b[1] = Matrix.sumEl(a, l);
                b[2] = Matrix.same(a);
                Console.WriteLine("Получившийся ступенчатый массив: ");
                InpOutp.OutputRes(b);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Out Range Error");
            }
            catch (FormatException)
            {
                Console.WriteLine("Format Error");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
