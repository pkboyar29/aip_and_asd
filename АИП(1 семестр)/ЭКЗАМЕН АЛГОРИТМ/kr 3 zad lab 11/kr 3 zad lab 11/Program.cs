using System;

namespace kr_3_zad_lab_11
{/*3. Дан двумерный массив размером N*N, заполненный целыми числами.
Сформировать ступенчатый массив, содержащий 4 строки, состоящие:
а) каждый элемент которого равен количеству элементов соответствующего
столбца двумерного массива, больших данного числа.
б) каждый элемент которого равен сумме элементов соответствующей строки
двумерного массива, меньших данного числа.
в) каждый элемент которого равен номеру строки, в которой все элементы
одинаковы*/
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Введите размерность двумерного массива");
                int n = int.Parse(Console.ReadLine());
                int[,] a = new int[n, n];
                Matrix.Input(a);
                Matrix.Output(a);
                Console.WriteLine("");
                StupMas.Output(StupMas.NewMas(a, 3,n));
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
