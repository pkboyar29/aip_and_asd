using System;
//  После каждого элемента дека вставить сумму всех элементов дека. Дек состоит из целых чисел.
namespace lab6_18
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
        static void SumAfter(Deque<int> tmp)
        {
            // вычисляем сумму элементов с помощью цикла foreach
            int sum = 0;
            foreach (int x in tmp)
            {
                sum += x;
            }
            int count = tmp.Count;
            // теперь добавляем сумму после каждого элемента с помощью цикла for (он будет срабатывать столько раз, сколько элементов в деке
            for (int i = 0; i < count; i++)
            {
                // убираем с начала дека элемент и запоминаем его в переменную b
                int b = tmp.Pop();
                // теперь добавляем этот элемент в конец дека, а после него сумму всех элементов, и так с каждым элементом
                tmp.PushTail(b);
                tmp.PushTail(sum);
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
                    SumAfter(s);
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
