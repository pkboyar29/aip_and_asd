using System;
// lab8-20 Удалить элементы списка, имеющие равных соседей. Под соседями понимаются элементы, находящиеся перед и после текущего элемента.
namespace lab8_20
{
    class Program
    {
        public static doubly<int> Input(int N)
        {
            doubly<int> tmp = new doubly<int>();
            Random rnd = new Random();
            for (int i = 0; i < N; i++)
            {
                tmp.AddLast(rnd.Next(20));
            }
            return tmp;
        }

        public static void DeleteEqualNeighbors(doubly<int> tmp)
        {
            // начинаем со второго элемента и заканчиваем предпоследним (так как у первого и последнего элемента нет соседей с одной стороны)
            for (int i = 2; i < tmp.Count; i++)
            {
                // сравниваем предыдущий и следующий элемент, и если они не равны, удаляем элемент по выбранному номеру
                if (tmp.SearchByNumber(i - 1) == tmp.SearchByNumber(i + 1))
                {
                    tmp.Del(i);
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
                                    doubly<int> s = Input(N);
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
                                doubly<int> s1 = new doubly<int>();
                                s1.AddLast(7);
                                s1.AddLast(6);
                                s1.AddLast(7);
                                s1.AddLast(45);
                                s1.AddLast(8);
                                s1.AddLast(3);
                                s1.AddLast(56);
                                s1.AddLast(3);
                                s1.AddLast(31);
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
