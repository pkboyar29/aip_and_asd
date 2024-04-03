using System;
// Заполнить дек целыми положительными числами. Вставить в дек сегодняшнее число до элемента, который равен числу вводимому с клавиатуры.
namespace lab6_3
{
    class Program
    {
        /// <summary>
        /// Выводит содержимое дека на экран
        /// </summary>
        /// <param name="tmp"></param>
        static void Output(Deque<int> tmp)
        {
            foreach (int x in tmp)
            {
                Console.Write("{0} ", x);
            }
        }
        /// <summary>
        /// Заполняет дек случайными числами
        /// </summary>
        /// <param name="N"></param>
        /// <returns></returns>
        static Deque<int> Input(int N)
        {
            Deque<int> tmp = new Deque<int>();
            Random rnd = new Random();
            for (int i = 0; i < N; i++)
                tmp.PushTail(rnd.Next(20));
            return tmp;
        }

        static void Add(Deque<int> tmp, int N)
        {
            // в переменной count - кол-во элементов дека
            int count = tmp.Count;
            // с помощью цикла for добавляем до числа, введённого с клавы сегодняшнее число
            for (int i = 0; i < count; i++)
            {
                // запоминаем в b удаленный первый элемент дека, который будем потом сравнивать
                int b = tmp.Pop();
                // если равны, то добавляем сегодняшнюю дату
                if (b == N)
                {
                    // DateTime.Today.Day - выводит сегодняшний день
                    tmp.PushTail(DateTime.Today.Day);
                    tmp.PushTail(b);
                } else
                {
                    tmp.PushTail(b);
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
                    Console.Write("Введите число: ");
                    int b = int.Parse(Console.ReadLine());
                    Add(s, b);
                    Output(s);
                }
                else
                {
                    Console.WriteLine("Неправильный ввод данных");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
