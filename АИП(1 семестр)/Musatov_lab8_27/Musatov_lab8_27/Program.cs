using System;
/* Дано целое число N. Задать N элементов одномерного массива. Найти количество
участков, на которых его элементы монотонно убывают.  */
namespace Musatov_lab8_27
{
    class Program
    {
        static void Input(int[] temp)
        {
            Random rnd = new Random();
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = rnd.Next(20);
            }
            /* for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = int.Parse(Console.ReadLine());
            } */

        }
        static void Output(int[] temp)
        {
            for (int i = 0; i < temp.Length; i++)
            {
                Console.Write("{0} ", temp[i]);
            }
        }
        static int prover(int[] temp)
        {
            int min = int.MinValue;
            int count = 0;
            for (int i = 0; i < temp.Length-1; i++)
            {
                if (temp[i] >= min && temp[i] > temp[i + 1])
                    count++;
                min = temp[i];
            }
            return count;
        }
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Введите размерность массива: ");
                int N = int.Parse(Console.ReadLine());
                int[] arr = new int[N];
              /*  Console.WriteLine("Введите элементы массива: "); */
                Input(arr);
                Console.WriteLine();
                Output(arr);
                Console.WriteLine();
                Console.WriteLine("Количество участков, где элементы массива монотонно убывают: {0}", prover(arr));
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
