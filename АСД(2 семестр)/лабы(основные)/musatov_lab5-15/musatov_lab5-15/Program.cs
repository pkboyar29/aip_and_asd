using System;
// Проверьте на равенство две очереди. Очереди считаются равными, если равны элементы на соответствующих позициях очереди.
namespace musatov_lab5_15
{
    class Program
    {
        /// <summary>
        /// Выводим очередь на экран
        /// </summary>
        /// <param name="tmp">очередь, которую мы хотим вывести</param>
        static void Output(Queue<int> tmp)
        {
            foreach (int x in tmp)
            {
                Console.Write($"{x} ");
            }

        }
        /// <summary>
        /// Заполняем очередь случайными значениями
        /// </summary>
        /// <param name="N">количество элементов очереди</param>
        /// <returns></returns>
        static Queue<int> InputRnd(int N)
        {
            Queue<int> tmp = new Queue<int>();
            Random rnd = new Random();
            for (int i = 0; i < N; i++)
                tmp.Enqueue(rnd.Next(10, 20));
            return tmp;
        }
        /// <summary>
        /// Ручной ввод 
        /// </summary>
        /// <returns></returns>
        static Queue<int> ManualInput(int N)
        {
            Queue<int> tmp = new Queue<int>();
            Console.WriteLine("Введите значения очереди: ");
            for (int i = 0; i < N; i++)
            {
                int elem;
                string txt = Console.ReadLine();
                if (int.TryParse(txt, out elem))
                {
                    tmp.Enqueue(elem);
                } else
                {
                    throw new Exception("Неправильно введено значение!");
                }
            }
            return tmp;
        }
        /// <summary>
        /// Сравниваем очереди
        /// </summary>
        /// <param name="tmp">первая очередь</param>
        /// <param name="tmp1">вторая очередь</param>
        /// <returns></returns>
        static bool Compare(Queue<int> tmp, Queue<int> tmp1)
        {
            int var = 1; // переменная, которую мы будем обнулять в случае, если хотя бы один элемент одной очереди не равен
            // в b1 и b2 запоминаем верхние элементы очередей tmp и tmp1 соответственно, позже будем сравнивать именно b1 и b2
            int b1 = tmp.Dequeue();
            int b2 = tmp1.Dequeue();
            // в tmp2 и tmp3 будем обратно возвращать очереди tmp и tmp1, из которых мы берём элементы на сравнение
            Queue<int> tmp2 = new Queue<int>();
            Queue<int> tmp3 = new Queue<int>();
            while (tmp.Count != 0 || tmp1.Count != 0) // пока основные очереди не опустошатся, цикл работает, дальше уже сравнивать нечего будет
            {
                if (b1 != b2) 
                {
                    var = 0; 
                }
                // перекидываем в вспомогательные очереди b1 и b2
                tmp2.Enqueue(b1); 
                tmp3.Enqueue(b2);
                // меняем b1 и b2 на следующие элементы очередей
                b1 = tmp.Dequeue();
                b2 = tmp1.Dequeue();
            }
            // обратно перекидываем элементы в основные очереди
            while (tmp2.Count != 0)
            {
                tmp.Enqueue(tmp2.Dequeue());
            }
            while (tmp3.Count != 0)
            {
                tmp1.Enqueue(tmp3.Dequeue());
            }
            // проверяем результат
            if (var == 0)
            {
                return false;
            } else
            {
                return true;
            }
        }
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Введите количество элементов первой очереди: ");
                string txt1 = Console.ReadLine();
                Console.Write("Введите количество элементов второй очереди: ");
                string txt2 = Console.ReadLine();
                int N1;
                int N2;
                if (!int.TryParse(txt1, out N1) || !int.TryParse(txt2, out N2) || N1 <= 0 || N2 <= 0)
                {
                    Console.WriteLine("Введено не натуральное число!");
                }
                else
                {
                    // Рандомный ввод
                    /*Queue<int> s1 = InputRnd(N1);
                    Console.Write("Первая очередь: ");
                    Output(s1);
                    Console.WriteLine();
                    Queue<int> s2 = InputRnd(N2);
                    Console.Write("Вторая очередь: ");
                    Output(s2);
                    Console.WriteLine();*/
                    // Ручной ввод
                    Queue<int> s1 = ManualInput(N1);
                    Console.Write("Первая очередь: ");
                    Output(s1);
                    Console.WriteLine();
                    Queue<int> s2 = ManualInput(N2);
                    Console.Write("Вторая очередь: ");
                    Output(s2);
                    Console.WriteLine();
                    if (s1.Count != s2.Count) // если количество элементов не равно, то очереди уже не равны (пример s: 1 1 1 1 и s1: 1 1 1)
                    {
                        Console.WriteLine("Очереди разной длины!");
                    }
                    else if (Compare(s1, s2))
                    {
                        Console.WriteLine("Очереди равны!");
                    } else
                    {
                        Console.WriteLine("Очереди не равны!");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
