using System;
using System.Collections;

namespace Musatov_lab4_20
{
    class Program
    {
        /// <summary>
        /// lab4-20 Отсортировать стек, заполненный целыми числами, по убыванию. На дне стека должен быть максимальный элемент, в вершине – минимальный. Использовать только нужное количество стеков.
        /// </summary>
        /// <param name="tmp">исходный стек</param>
        static void SortStack(Stack tmp)
        {
            Stack tmp1 = new Stack();
            while (tmp.Count != 0)
            {
                int poppedElement = (int)tmp.Pop();
                while (tmp1.Count != 0 && poppedElement < (int)tmp1.Peek())
                {
                    tmp.Push(tmp1.Pop());
                }
                tmp1.Push(poppedElement);
            }
            while (tmp1.Count != 0)
            {
                tmp.Push(tmp1.Pop());
            }
        }

        /// <summary>
        /// заполняет стек случайными целыми числами
        /// </summary>
        /// <param name="N">количество элементов стека</param>
        /// <returns></returns>
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
        /// выводит элементы стека на экран
        /// </summary>
        /// <param name="tmp">исходный стек</param>
        static void Output(Stack tmp)
        {
            foreach (int x in tmp)
            {
                Console.WriteLine("{0} ", x);
            }
        }
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Введите количество элементов стека: ");
                string txt = Console.ReadLine();
                int N;
                if (!int.TryParse(txt, out N) || N <= 0)
                {
                    Console.WriteLine("Введено не натуральное число!");
                }
                else
                {
                    Stack s = Input(N);
                    Console.WriteLine("Стек до сортировки(на дне первый элемент)");
                    Output(s);
                    Console.WriteLine();
                    SortStack(s);
                    Console.WriteLine("Сортировка по убыванию");
                    Console.WriteLine("Стек после сортировки(на дне должен быть максимальный элемент, в вершине - минимальный): ");
                    Output(s);
                }
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
