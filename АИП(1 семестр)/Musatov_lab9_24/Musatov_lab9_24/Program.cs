using System;
/*Дан массив размера N и целое число K (1 ≤ K < N). Осуществить циклический сдвиг
элементов массива вправо на K позиций по принципу задания 22. */

namespace Musatov_lab9_24
{
    class Program
    {
        static void Input(int[] temp)
        {
            Random rnd = new Random();
            for (int i = 0; i < temp.Length; i++)
                temp[i] = rnd.Next(-20, 20);

        }
        static void Output(int[] temp)
        {
            for (int i = 0; i < temp.Length; i++)
            {
                Console.Write("{0} ", temp[i]);
            }
        }
        static void rightk(int[] temp, int k)
        {
            int tmp;
            int nexti = 0;
            for (int i = 0; i < temp.Length; i++)
            {
                nexti += k;
                nexti %= temp.Length;
                tmp = temp[nexti];
                temp[nexti] = temp[0];
                temp[0] = tmp;
            }
        }
        static void Main(string[] args)
        {
            try {
                int N = 5;
                int[] arr = new int[N];
                Input(arr);
                Output(arr);
                Console.WriteLine();
                int k = int.Parse(Console.ReadLine());
                rightk(arr, k);
                Output(arr);
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
