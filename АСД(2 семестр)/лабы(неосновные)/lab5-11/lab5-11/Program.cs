using System;
// В начало очереди поместить элементы с четными номерами, а вконец – с нечетными.
namespace lab5_11
{
    class Program
    {
        static void Pomes(Queue<int> tmp)
        {
            Queue<int> tmp1 = new Queue<int>(); // нечетные
            Queue<int> tmp2 = new Queue<int>(); // четные
            int ident = 1;
            while (tmp.Count != 0)
            {
                if (ident == 1)
                {
                    tmp1.Enqueue(tmp.Dequeue());
                    ident++;
                }
                if (ident == 2)
                {
                    tmp2.Enqueue(tmp.Dequeue());
                    ident--;
                }
            }
            while (tmp2.Count != 0)
            {
                tmp.Enqueue(tmp1.Dequeue());
            }
            while (tmp1.Count != 0)
            {
                tmp.Enqueue(tmp2.Dequeue());
            }
        }
        static Queue<int> Input(int n)
        {
            Queue<int> tmp = new Queue<int>();
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
            {
                tmp.Enqueue(rnd.Next(-2, 10));
            }
            return tmp;
        }
        static void Output(Queue<int> tmp)
        {
            foreach (int x in tmp)
            {
                Console.Write("{0} ", x);
            }
        }
        static void Main(string[] args)
        {
            Console.Write("Введите n: ");
            int n = int.Parse(Console.ReadLine());
            Queue<int> s = Input(n);
            Output(s);
            Console.WriteLine();
            Pomes(s);
            Output(s);
        }
    }
}
