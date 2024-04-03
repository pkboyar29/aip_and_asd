using System;
// Удалить четные элементы дека, заполненного случайным образом целыми числами.
namespace lab6_13
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
        /// <summary>
        /// Удаляет из дека чётные элементы
        /// </summary>
        /// <param name="tmp"></param>
        static void Delete(Deque<int> tmp)
        {
            // запоминаем в переменную count количество элементов дека
            int count = tmp.Count;
            // с помощью цикла for удаляем из дека все чётные элементы (цикл срабатывает столько же раз, сколько и элементов в деке (переменная count))
            for (int i = 0; i < count; i++)
            {
                // в переменную b запоминаем первый элемент дека, и так с каждой итерацией цикла
                int b = tmp.First();
                // теперь сравниваем эту переменную, если она чётная, мы просто удаляем первый элемент дека (tmp.pop()), иначе мы добавляем первый элемент дека в конец (pushtail - добавляет в конец), таким образом дек сохраняет текущую последовательность, и мы не использовали дополнительного(вспомогательного) дека
                if (b % 2 == 0)
                {
                    tmp.Pop();
                }
                else
                {
                    tmp.PushTail(tmp.Pop());
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
                    Delete(s);
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
