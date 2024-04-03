using System;
// lab6-25 Дан дек из целых чисел, заданных случайным образом. Если дек содержит четное количество элементов, то добавить в середину дека максимальный элемент; если же дек содержит нечетное количество элементов, то удалить из него средний.
namespace lab6_25
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
        /// <summary>
        /// Вычисляет максимальный элемент дека
        /// </summary>
        /// <param name="tmp"></param>
        /// <returns></returns>
        static int Max(Deque<int> tmp)
        {
            int max = 0;
            for (int i = 0; i < tmp.Count; i++)
            {
                // в переменную b запоминаем первый элемент дека, заодно удаляем его, затем сравниваем его с максимальным, и если что обновляем максимум, и потом закидываем этот элемент в конец дека
                int b = tmp.Pop();
                if (b > max)
                {
                    max = b;
                }
                tmp.PushTail(b);
            }
            return max;
        }
        static void EvenOdd(Deque<int> tmp)
        {
            // запоминаем в переменную max максимальный элемент дека через прошлый метод 
            int max = Max(tmp);
            int count = tmp.Count;
            // если количество элементов чётное
            if (tmp.Count % 2 == 0)
            {
                // цикл for срабатывает столько раз, сколько элементов в деке
                for (int i = 0; i < count; i++)
                {
                    // когда мы доходимо до середины, закидываем в конец max
                    if (i == (tmp.Count / 2))
                    {
                        tmp.PushTail(max);
                    }
                    // и в каждой итерации цикла закидываем первый элемент дека в конец
                    tmp.PushTail(tmp.Pop());
                }
            }
            // если количество элементов нечётное
            else
            {
                for (int i = 0; i < count; i++)
                {
                    // когда доходим до середины, просто удаляем элемент
                    if (i == (tmp.Count / 2))
                    {
                        tmp.Pop();
                    }
                    else
                    {
                        // и в каждой итерации цикла закидываем первый элемент дека в конец
                        tmp.PushTail(tmp.Pop());
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Введите размерность дека: ");
                string txt = Console.ReadLine();
                int N;
                if (int.TryParse(txt, out N))
                {
                    Deque<int> s = Input(N);
                    Output(s);
                    Console.WriteLine();
                    EvenOdd(s);
                    Output(s);
                } else
                {
                    Console.WriteLine("Неправильный ввод данных");
                }
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
