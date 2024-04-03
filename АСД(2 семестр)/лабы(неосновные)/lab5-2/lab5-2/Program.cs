using System;

// Сравнить модули сумм положительных и отрицательных элементов очереди.Очередь заполнена целыми числами.
namespace lab5_2
{
    class Program
    {
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

        static int Compare(Queue<int> tmp)
        {
            int sumNEG = 0;
            int sum = 0;
            foreach (int x in tmp)
            {
                if (x < 0)
                {
                    sumNEG += x;
                } else
                {
                    sum += x;
                }
            }

            sumNEG = Math.Abs(sumNEG);

            if (sumNEG > sum)
            {
                return 2;
            } else if (sumNEG == sum)
            {
                return 1;
            } else
            {
                return 0;
            }
        }
        static void Main(string[] args)
        {
            Console.Write("Введите n: ");
            int n = int.Parse(Console.ReadLine());
            Queue<int> s = Input(n);
            Output(s);
            Console.WriteLine();
            if (Compare(s) == 2)
            {
                Console.WriteLine("Сумма отрицательных чисел больше суммы положительных");
            } else if (Compare(s) == 1)
            {
                Console.WriteLine("Сумма отрицательных чисел равна сумме положительных");
            } else if (Compare(s) == 0)
            {
                Console.WriteLine("Сумма отрицательнх чисел меньше суммы положительных");
            }
        }
    }
}
