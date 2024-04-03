using System;

namespace dequeLABS
{
    class Program
    {
        static void Output(Deque<int> tmp)
        {
            foreach (int x in tmp)
            {
                Console.Write("{0} ", x);
            }
        }
        static Deque<int> Input(int N)
        {
            Deque<int> tmp = new Deque<int>();
            Random rnd = new Random();
            for (int i = 0; i < N; i++)
                tmp.PushTail(rnd.Next(5, 15));
            return tmp;
        }
        // lab6-2 Дек состоит из целых чисел. Вставить в этот дек ноль после числа вводимого с клавиатуры.
        static void NullAfterNumber(Deque<int> tmp, int num)
        {
            Deque<int> tmp1 = new Deque<int>();
            while (tmp.Count != 0)
            {
                int b = tmp.First();
                if (b == num)
                {
                    tmp1.PushTail(b);
                    tmp1.PushTail(0);
                } else
                {
                    tmp1.PushTail(b);
                }
                tmp.Pop();
            }
            while (tmp1.Count != 0)
            {
                tmp.PushTail(tmp1.Pop());
            }
        }
        // Заполнить дек случайным образом целыми числами. Найти максимальный элемент в образовавшемся деке и вставить до и после него ноль.
        static void NullBefAftMaxEl(Deque<int> tmp)
        {
            Deque<int> tmp1 = new Deque<int>();
            int max = 0;
            while (tmp.Count != 0)
            {
                int b = tmp.Pop();
                if (b > max)
                {
                    max = b;
                }
                tmp1.PushTail(b);
            }
            while (tmp1.Count != 0)
            {
                int j = tmp1.Pop();
                if (j == max)
                {
                    tmp.PushTail(0);
                    tmp.PushTail(j);
                    tmp.PushTail(0);
                } else
                {
                    tmp.PushTail(j);
                }
            }
        }

        // lab6-7 Дек заполнен случайными целыми числами.Сортировать данный дек по возрастанию.
        static void IncreasingofDeque(Deque<int> tmp)
        {
            Deque<int> tmp1 = new Deque<int>();
            while (tmp.Count != 0)
            {
                int b = tmp.Pop();
                while (b < tmp1.First() && tmp1.Count != 0)
                {
                    tmp.PushTail(tmp1.Pop());
                }
                tmp1.Push(b);
            }
            while (tmp1.Count != 0)
            {
                tmp.PushTail(tmp1.Pop());
            }
        }
        static int MaxElOfDeque(Deque<int> tmp)
        {
            int max = 0;
            for (int i = 0; i < tmp.Count; i++)
            {
                int b = tmp.Pop();
                if (b > max)
                {
                    max = b;
                }
                tmp.PushTail(b);
            }
            return max;
        }
        // lab6-25 Дан дек из целых чисел, заданных случайным образом. Если дек содержит четное количество элементов, то добавить в середину дека максимальный элемент; если же дек содержит нечетное количество элементов, то удалить из него средний
        static void EvenOdd(Deque<int> tmp)
        {
            int max = MaxElOfDeque(tmp);
            int count = tmp.Count;
            if (tmp.Count % 2 == 0)
            {
                for (int i = 0; i < count; i++)
                {
                    if (i == (tmp.Count / 2))
                    {
                        tmp.PushTail(max);
                    }
                    tmp.PushTail(tmp.Pop());
                }
            } else
            {
                for (int i = 0; i < count; i++)
                {
                    if (i == (tmp.Count / 2))
                    {
                        tmp.Pop();
                    } else
                    {
                        tmp.PushTail(tmp.Pop());
                    }
                }
            }
        }
        // . В деке находятся целые числа. Добавить в дек столько элементов, чтобы он стал в два раза длиннее и симметричным, то есть: первый элемент был равен последнему, второй – предпоследнему и так далее.
        static void Simm(Deque<int> tmp)
        {
            Deque<int> tmp1 = new Deque<int>();
            for (int i = 0; i < tmp.Count; i++)
            {
                int b = tmp.First();
                tmp1.Push(b);
                tmp.PushTail(tmp.Pop());
            }
            while (tmp1.Count != 0)
            {
                tmp.PushTail(tmp1.Pop());
            }
        }
        static void Main(string[] args)
        {
            Console.Write("Введите размерность дека: ");
            int N = int.Parse(Console.ReadLine());
            Deque<int> s = Input(N);
            Output(s);
            Console.WriteLine();
            EvenOdd(s);
            Output(s);
        }
    }
}
