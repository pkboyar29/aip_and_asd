using System;
using System.Collections;
// Дан стек из целых чисел, заполненный случайным образом. Удалить из него все отрицательные элементы, используя второй стек и одну переменную.

namespace Musatov_lab4_1
{
    class Program
    {
        /// <summary>
        /// Заполняет стэк случайными числами
        /// </summary>
        static Stack Input(int N)
        {
            Stack tmp = new Stack();
            Random rnd = new Random();
            for (int i = 0; i < N; i++)
            {
                tmp.Push(rnd.Next(-10, 10));
            }
            return tmp;
        }
        /// <summary>
        /// Выводит элементы стека на экран
        /// </summary>
        /// <param name="tmp"></param>
        static void Output(Stack tmp)
        {
            foreach (int x in tmp)
            {
                Console.Write("{0} ", x);
            }
        }

        static void Delete(Stack tmp)
        {
            Stack tmp1 = new Stack();
            int a = 0;
            while (tmp.Count != 0)
            {
                tmp1.Push(tmp.Pop());
            }
            while (tmp1.Count != 0)
            {
                a = (int)tmp1.Pop();
                if (a >= 0)
                {
                    tmp.Push(a);
                } 
            }
        }
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Введите размерность стека: ");
                string txt = Console.ReadLine();
                int N;
                if (!int.TryParse(txt, out N) || N <= 0)
                {
                    Console.WriteLine("Вы ввели не натуральное число");
                } else {
                    Stack s = Input(N);
                    Console.WriteLine("Стек до удаления из него отрицательных элементов: ");
                    Output(s);
                    Console.WriteLine();
                    Delete(s);
                    Console.WriteLine("Стек после удаления из него отрицательных элементов: ");
                    Output(s);

                }
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
