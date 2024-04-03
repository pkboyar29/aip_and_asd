using System;
//Удалить элементы списка, имеющие равных соседей. Под соседями
//понимаются элементы, находящиеся перед и после текущего элемента.

namespace musatov_lab7_20
{
    class Program
    {
        /// <summary>
        /// Заполняет список случайными значениями
        /// </summary>
        /// <param name="N"></param>
        /// <returns></returns>
        public static SinglyLinkedList<int> Input(int N)
        {
            SinglyLinkedList<int> tmp = new SinglyLinkedList<int>();
            Random rnd = new Random();
            for (int i = 0; i < N; i++)
            {
                tmp.AddLast(rnd.Next(8));
            }
            return tmp;
        }
        /// <summary>
        /// Удаляет из списка все элементы, имеющие равных соседей
        /// </summary>
        public static void DeleteEqualNeighbors(SinglyLinkedList<int> tmp)
        {
            int count = tmp.Count;
            for (int i = 2; i < count; i++)
            {
                if (tmp.SearchByNumber(i - 1) == tmp.SearchByNumber(i + 1))
                {
                    tmp.Del(i);
                    count--;
                }
            }
        }

        static void Main(string[] args)
        {
            try
            {
                // создать объект пользовательского класса
                ConsoleKeyInfo K;
                do
                {
                    Console.Clear(); //очистка экрана перед выводом меню
                    Console.WriteLine("1.Заполнить список случайными числами, вывести его на экран и удалить из него элементы, которые имеют равных соседей");
                    Console.WriteLine("2.Использовать базовые значения, чтобы посмотреть работу метода удаления");
                    Console.WriteLine("Esc. Выход из программы");
                    K = Console.ReadKey(); //считывание кода вводимой клавиши
                    switch (K.Key)
                    {
                        case ConsoleKey.D1: // если нажата клавиша с цифрой 1
                            {
                                Console.WriteLine();
                                Console.Write("Введите количество элементов списка: ");
                                string txt = Console.ReadLine();
                                int N;
                                if (int.TryParse(txt, out N))
                                {
                                    SinglyLinkedList<int> s = Input(N);
                                    Console.WriteLine("Текущий список {0}", s.ToString());
                                    DeleteEqualNeighbors(s);
                                    Console.WriteLine("В списке удалены элементы, имеющие равных соседей {0}", s.ToString());
                                }
                                else
                                {
                                    Console.WriteLine("Неправильный ввод данных");
                                }
                                break;
                            }
                        case ConsoleKey.D2: // если нажата клавиша с цифрой 2
                            {
                                Console.WriteLine();
                                SinglyLinkedList<int> s1 = new SinglyLinkedList<int>();
                                s1.AddLast(7);
                                s1.AddLast(6);
                                s1.AddLast(7);
                                s1.AddLast(45);
                                s1.AddLast(8);
                                s1.AddLast(3);
                                s1.AddLast(56);
                                s1.AddLast(3);
                                s1.AddLast(3);
                                s1.AddLast(56);
                                Console.WriteLine("Базовый список для просмотра работы метода {0}", s1.ToString());
                                DeleteEqualNeighbors(s1);
                                Console.WriteLine("В списке удалены элементы, имеющие равных соседей {0}", s1.ToString());
                                break;
                            }
                        default: break;
                    }
                    // приостанавливаем выполнение текущего потока на заданное число времени. Время измеряется в миллисекундах
                    System.Threading.Thread.Sleep(40000); // 10 сек.
                }
                while (K.Key != ConsoleKey.Escape);// цикл заканчивается, если нажата клавиша Esc
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
