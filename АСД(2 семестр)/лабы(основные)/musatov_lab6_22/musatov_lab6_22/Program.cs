using System;
//Дек заполнен целыми положительными и отрицательными числами. Удалить из дека все положительные четные числа.
namespace musatov_lab6_22
{
    class Program
    {
        static void Delete(Deque<int> tmp)
        {
            int count = tmp.Count;
            for (int i = 0; i < count; i++)
            {
                int b = tmp.First();
                if (b > 0 && b % 2 == 0)
                {
                    tmp.Pop();
                } else
                {
                    tmp.PushTail(tmp.Pop());
                }
            }
        }
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
                tmp.PushTail(rnd.Next(-15, 15));
            return tmp;
        }
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Введите размерность дека: ");
                string txt = Console.ReadLine();
                int N;
                if (!int.TryParse(txt, out N))
                {
                    Console.WriteLine("Неправильный ввод данных");
                }
                else
                {
                    Deque<int> s = Input(N);
                    Console.WriteLine("Текущий дек: ");
                    Output(s);
                    Console.WriteLine();
                    Delete(s);
                    Console.WriteLine("Дек после изменений: ");
                    Output(s);
                    Console.WriteLine();
                }
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
