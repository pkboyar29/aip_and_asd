using System;
/* Дан массив размера N (N — четное число). Поменять местами его первый элемент со
вторым, третий — с четвертым и т. д. */

namespace Musatov_lab9_13
{
    class Program
    {
        static void Input(int[] temp)
        {
            Random rnd = new Random();
            for (int i = 0; i < temp.Length; i++)
                temp[i] = rnd.Next(-20, 20); 
         /*   for (int i = 0; i < temp.Length; i++)
                temp[i] = int.Parse(Console.ReadLine()); */

        }
        static void Output(int[] temp)
        {
            for (int i = 0; i < temp.Length; i++)
            {
                Console.Write("{0} ", temp[i]);
            }
        }
        static void ChArr(int[] temp)
        {
            int s = 0;
            for (int i = 0; i < temp.Length; i++)
            { // 2 3 4 5
                if (i % 2 == 0)
                {
                    s = temp[i]; // s = 2
                    temp[i] = temp[i + 1]; // 3 3 4 5 
                } else
                {
                    temp[i] = s; // 3 2 4 5
                }
                
            }
        }


        static void Main(string[] args)
        {
            try
            {
                int N = 12;
                int[] arr = new int[N];
                Input(arr);
                Output(arr);
                Console.WriteLine();
                ChArr(arr);
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
