using System;
// Дана очередь, содержащая целые числа. Удалить из очереди все неповторяющиеся элементы.
namespace musatov_lab5_27
{
    class Program
    {
        /// <summary>
        /// Выводит элементы очереди на экран
        /// </summary>
        /// <param name="tmp"></param>
        static void Output(MyQueue<int> tmp)
        {
            foreach (int x in tmp)
            {
                Console.Write($"{x} ");
            }

        }
        /// <summary>
        /// Заполняет очередь элементами
        /// </summary>
        /// <param name="N"></param>
        /// <returns></returns>
        static MyQueue<int> Input(int N)
        {
            MyQueue<int> tmp = new MyQueue<int>();
            Random rnd = new Random();
            for (int i = 0; i < N; i++)
                tmp.Enqueue(rnd.Next(10, 20));
            return tmp;
        }

        static void DelNoRepEl(MyQueue<int> tmp)
        {
            MyQueue<int> tmp1 = new MyQueue<int>();
            int elem = 0; // оставить нулём
            int count = tmp.Count;
            int fixcount = count;
            int i = count;
            while (true)
            {
                // находим элемент, который мы будем сравнивать с остальными
                // count с каждым разом будет на 1 меньше; а i будет оставаться равен каунту очереди, так мы будем проверять каждый элемент по индексу и ничего не пропустим
                if (count > 0)
                {
                    foreach (int x in tmp)
                    {
                        if (count == i)
                        {
                            elem = x;
                            break;
                        }
                        else
                        {
                            i--;
                        }
                    }
                    count--;
                }
                else
                {
                    break;
                }
                int ident = 0;
                // фиксируем, если у нас элемент не повторяется с помощью переменной ident
                while (tmp.Count != 0)
                {
                    if (elem == tmp.Peek())
                    {
                        ident++;
                    }
                    tmp1.Enqueue(tmp.Dequeue());
                }
                // избавляемся от элемента, если он у нас не повторяется
                while (tmp1.Count != 0)
                {
                    if (elem == tmp1.Peek() && ident == 1)
                    {
                        tmp1.Dequeue();
                        fixcount--;
                    } else
                    {
                        tmp.Enqueue(tmp1.Dequeue());
                    }
                }
                ident = 0;
                i = fixcount;
            }
    }
        static void Main(string[] args)
        {
           try
            {
                Console.Write("Введите количество элементов очереди: ");
                string txt = Console.ReadLine();
                int N;
                if (!int.TryParse(txt, out N))
                {
                    Console.WriteLine("Неправильынй ввод данных");
                } else
                {
                    MyQueue<int> s = Input(N);
                    Console.Write("Исходная очередь: ");
                    Output(s);
                    Console.WriteLine();
                    DelNoRepEl(s);
                    Console.Write("Текущая очередь: ");
                    Output(s);
                }
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
