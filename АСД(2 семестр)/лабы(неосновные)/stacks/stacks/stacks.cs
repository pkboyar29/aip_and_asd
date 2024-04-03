using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace stacks
{
    class stacks
    {
        public static Stack Input(int N)
        {
            Stack tmp = new Stack();
            Random rnd = new Random();
            for (int i = 0; i < N; i++)
            {
                tmp.Push(rnd.Next(1, 9));
            }
            return tmp;
        }
        /// <summary>
        /// Выводит элементы стека на экран, начиная с верхнего
        /// </summary>
        /// <param name="tmp"></param>
        public static void Output(Stack tmp)
        {
            foreach (int x in tmp)
            {
                Console.WriteLine(x);
            }
        }
        /// <summary>
        /// lab4-21 Дан стек, заполненный случайными целыми числами. Удалить из стека повторяющиеся элементы, оставив по одному.
        /// </summary>
        /// <param name="tmp"></param>
        public static void DeleteRepeatElem(Stack tmp)
        {
            Stack tmp1 = new Stack();
            int elem = 0;
            int count = tmp.Count;
            int count1 = count;
            int count2 = 0;
            int i = count;
            while (true)
            {
                // вычисляет элемент, который мы будем сравнивать с остальными
                if (count > 0)
                {
                    foreach (int x in tmp)
                    {
                        if (count == i)
                        {
                            elem = x;
                            break;
                        } else
                        {
                            i--;
                        }
                    }
                    i = count1;
                    count--;
                } else
                {
                    break;
                }
                // основной цикл, который убирает повторяющиеся элементы
                while (tmp.Count != 0)
                {
                    if (elem == (int)tmp.Peek() && count2 == 0)
                    {
                        tmp1.Push(tmp.Pop());
                        count2++;
                    } else if (elem == (int)tmp.Peek() && count2 == 1)
                    {
                        tmp.Pop();
                    }
                    else
                    {
                        tmp1.Push(tmp.Pop());
                    }
                }
                // цикл, который делает основной стек в такой же последовательности, только уже без повторяющихся элементов elem; чтобы с ним дальше работать
                while (tmp1.Count != 0)
                {
                    tmp.Push(tmp1.Pop());
                }
                count2 = 0;
            }
        }

        /// <summary>
        /// lab4-20 Отсортировать стек, заполненный целыми числами, по убыванию. На дне стека должен быть максимальный элемент, в вершине – минимальный. Использовать только нужное количество стеков.
        /// </summary>
        /// <param name="tmp"></param>
        public static void SortStack(Stack tmp)
        {
            Stack tmp1 = new Stack();
            while (tmp.Count != 0) // когда полностью опустошится основной стек, то это значит, что вспомогательный стек уже отсортирован по возрастанию, и осталось обратно в основной стек засунуть все элементы вспомогательного, тогда сортировка уже будет по убыванию, что по условию задачи нам и нужно
            {
                int poppedElement = (int)tmp.Pop();
                while (tmp1.Count != 0 && poppedElement > (int)tmp1.Peek())
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
        /// lab4-10 Дан стек из целых чисел, заполненный случайными образом. Сравнить сумму положительных элементов с модулем суммы отрицательных элементов
        /// </summary>
        /// <param name="tmp">исходный стек</param>
        public static bool Compare(Stack tmp)
        {
            int sumOfPositive = 0;
            int sumOfNegative = 0;
            foreach (int x in tmp)
            {
                if (x > 0)
                {
                    sumOfPositive += x;
                }
                if (x < 0)
                {
                    sumOfNegative += x;
                }
            }
            sumOfNegative = Math.Abs(sumOfNegative);
            return sumOfPositive >= sumOfNegative;
        }
        /// <summary>
        /// lab4-9 Дан стек заполненный случайным образом из целых чисел. Поменять в данном стеке содержимое вершины и дна.
        /// </summary>
        /// <param name="tmp">исходный стек</param>
        public static void SwapFirstWithLast(Stack tmp)
        {
            int count = tmp.Count;
            int ident = 1;
            int firstEl = 0;
            int lastEl = 0;
            Stack tmp1 = new Stack();
            while (tmp.Count != 0)
            {
                if (ident == 1)
                {
                    firstEl = (int)tmp.Pop();
                }
                else if (ident == count)
                {
                    lastEl = (int)tmp.Pop();
                }
                else
                {
                    tmp1.Push(tmp.Pop());
                }
                ident++;
            }
            ident = 1;
            while (tmp.Count != count)
            {
                if (ident == 1)
                {
                    tmp.Push(firstEl);
                }
                else if (ident == count)
                {
                    tmp.Push(lastEl);
                }
                else
                {
                    tmp.Push(tmp1.Pop());
                }
                ident++;
            }
        }
        /// <summary>
        /// lab4-7(8) Дан стек заполненный элементами целого типа. Удалить из стека первый элемент и поместить его на дно стека.
        /// </summary>
        /// <param name="tmp">исходный стек</param>
        public static void CopyFirstElToBottom(Stack tmp)
        {
            int ident = 1;
            int firstEl = 0;
            Stack tmp1 = new Stack();
            while (tmp.Count != 0)
            {
                if (ident == 1)
                {
                    firstEl = (int)tmp.Pop();
                    ident++;
                }
                else
                {
                    tmp1.Push(tmp.Pop());
                }
            }
            while (tmp1.Count != 0)
            {
                if (ident == 2)
                {
                    tmp.Push(firstEl);
                    ident++;
                }
                else
                {
                    tmp.Push(tmp1.Pop());
                }
            }
        }
        /// <summary>
        /// lab4-6 Дан стек заполненный элементами целого типа. Удалить из стека предпоследний элемент.
        /// </summary>
        /// <param name="tmp"></param>
        public static void DeletePenultimate(Stack tmp)
        {
            int ident = 1;
            Stack tmp1 = new Stack();
            while (tmp.Count != 0)
            {
                tmp1.Push(tmp.Pop());
            }
            while (tmp1.Count != 0)
            {
                if (ident == 2)
                {
                    tmp1.Pop();
                }
                else
                {
                    tmp.Push(tmp1.Pop());
                }
                ident++;
            }
        }
        /// <summary>
        /// lab4-5 Дан стек из целых чисел, заполненный случайным образом. При помощи второго стека удалить последний отрицательный элемент.
        /// </summary>
        /// <param name="tmp">исходный стек</param>
        public static void DeleteLastNegative(Stack tmp)
        {
            int N = 0;
            int ident = 0;
            Stack tmp1 = new Stack();
            while (tmp.Count != 0)
            {
                tmp1.Push(tmp.Pop());
            }
            while (tmp1.Count != 0)
            {
                N = (int)tmp1.Pop();
                if (ident == 0 && N < 0)
                {
                    ident++;
                }
                else
                {
                    tmp.Push(N);
                }
            }

        }
        /// <summary>
        /// lab4-4 Удалить из стека, который составлен из целых чисел заданных случайным образом, каждый второй элемент. На дне находится первый элемент.
        /// </summary>
        /// <param name="tmp">исходный стек</param>
        public static Stack EveryTwo(Stack tmp)
        {
            int ident = 1;
            Stack res = new Stack();
            while (tmp.Count != 0)
            {
                if (ident == 2)
                {
                    tmp.Pop();
                    ident--;
                }
                else
                {
                    res.Push(tmp.Pop());
                    ident++;
                }
            }
            while (res.Count != 0)
            {
                tmp.Push(res.Pop());
            }
            return tmp;
        }
        /// <summary>
        ///lab4-2 Дан стек, заполненный целыми числами случайным образом. Удалить из стека все числа не кратные заданному с клавиатуры.
        /// </summary>
        /// <param name="tmp">исходный стек</param>
        /// <param name="del">заданное с клавиатуры число</param>
        public static void NoMultiple(Stack tmp, int del)
        {
            int N = 0;
            Stack tmp1 = new Stack();
            while (tmp.Count != 0)
            {
                tmp1.Push(tmp.Pop());
            }
            while (tmp1.Count != 0)
            {
                N = (int)tmp1.Pop();
                if (N % del == 0)
                {
                    tmp.Push(N);
                }
            }
        }
        /// <summary>
        /// lab4-3 Изменить исходный стек, поместив сумму всех его элементов на дно стека (в конец)
        /// </summary>
        /// <param name="tmp"></param>
        public static void SumOfStack3(Stack tmp)
        {
            int N = tmp.Count;
            int sum = 0;
            foreach (int x in tmp)
            {
                sum += x;
            }
            Stack tmp1 = new Stack();
            while (tmp.Count != 0)
            {
                tmp1.Push(tmp.Pop());
            }
            tmp.Push(sum);
            while (tmp1.Count != 0)
            {
                tmp.Push(tmp1.Pop());
            }
        }
        /// <summary>
        /// Возвращает сумму всех элементов стека (более простой код, с помощью foreach)
        /// </summary>
        /// <param name="tmp">исходный стек</param>
        /// <returns></returns>
        public static int SumOfStack2(Stack tmp)
        {
            int sum = 0;
            foreach (int x in tmp)
            {
                sum += x;
            }
            return sum;
        }
        /// <summary>
        /// Возвращает сумму всех элементов стека
        /// </summary>
        /// <param name="tmp">исходный стек</param>
        public static int SumOfStack(Stack tmp)
        {
            int sum = 0;
            Stack tmp1 = new Stack();
            int N = 0;
            while (tmp.Count != 0)
            {
                N = (int)tmp.Pop();
                tmp1.Push(N);
                sum += N;
            }
            while (tmp1.Count != 0)
            {
                tmp.Push(tmp1.Pop());
            }
            return sum;

        }
        /// <summary>
        /// Возвращает стек, в котором все элементы находятся в обратном порядке
        /// </summary>
        /// <param name="tmp">исходный стек, с которым происходят действия</param>
        /// <returns></returns>
        public static Stack ReverseStack(Stack tmp)
        {
            Stack tmp1 = new Stack();
            while (tmp.Count != 0)
            {
                tmp1.Push(tmp.Pop());
            }
            return tmp1;
        }
    }
}
