using System;
/* 3. Дан двумерный массив размером N*N, заполненный целыми числами.
Сформировать ступенчатый массив, содержащий 4 строки, состоящие:
а) каждый элемент которого равен количеству элементов соответствующего
столбца двумерного массива, больших данного числа.
б) каждый элемент которого равен сумме элементов соответствующей строки
двумерного массива, меньших данного числа.
в) каждый элемент которого равен номеру строки, в которой все элементы
одинаковы
*/
namespace Musatov_lab11_3
{
    class Program
    {
        static int[] monot(int[,] temp)
        {
            int[] arr = new int[0];
            int a;
            int count;
            int k = 0;
            for (int i = 0; i < temp.GetLength(0); i++)
            {
                count = 0;
                a = int.MinValue;
                for (int j = 0; j < temp.GetLength(1); j++)
                {
                    if (temp[i, j] > a)
                    {
                        count++;
                        a = temp[i, j];
                    }
                }
                if (count == temp.GetLength(1))
                {
                    Array.Resize(ref arr, arr.Length + 1);
                    arr[k++] = i;
                }
            }
            return arr;
        }
        static void Input(int[,] A)
        {
            Random rnd = new Random();
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    A[i, j] = rnd.Next(20);
                }
            }
        }
        static void Output(int[,] A)
        {
            Random rnd = new Random();
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    Console.Write("{0}\t", A[i, j]);
                }
                Console.WriteLine();
            }
        }
        static void OutputRes(int[][] A)
        {
            for (int i = 0; i < A.Length; i++)
            {
                for (int j = 0;  j < A[i].Length;  j++)
                {
                    Console.Write("{0} ", A[i][j]);
                }
                Console.WriteLine();
            }
        }
        
        static void Main(string[] args)
        {
                try { 
                Console.Write("Введите порядок матрицы: ");
                int N = int.Parse(Console.ReadLine());
                int[,] a = new int[N, N];
                Input(a);
                Output(a);
                int[][] b = new int[3][];
                /*b[0] = Matrix.EvenEl(a);
                b[1] = Matrix.MaxElColumn(a);
                b[2] = Matrix.Diag(a);
                Console.WriteLine("Первая строка будущего массива: чётные элементы исходной матрицы");
                Console.WriteLine("Вторая строка будущего массива: максимальные элементы каждого столбца исходной матрицы");
                Console.WriteLine("Третья строка будущего массива: элементы на главной диагонали и над ней");
                Console.WriteLine("Полученный ступенчатый массив, исходя из предыдущих условий: "); */
                b[0] = monot(a);
                OutputRes(b); 
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
