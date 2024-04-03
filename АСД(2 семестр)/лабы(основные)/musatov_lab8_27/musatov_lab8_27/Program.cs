using System;
// lab8-27 Проверить, упорядочены ли элементы списка по возрастанию
namespace musatov_lab8_27
{
    class Program
    {
        public static DoublyLinkedList<int> Input(int N)
        {
            DoublyLinkedList<int> tmp = new DoublyLinkedList<int>();
            Random rnd = new Random();
            for (int i = 0; i < N; i++)
            {
                tmp.AddLast(rnd.Next(8));
            }
            return tmp;
        }

        public static bool CheckForIncreasing(DoublyLinkedList<int> tmp)
        {
            bool ident = true;
            int prev = tmp.SearchByNumber(1);
            for (int i = 2; i <= tmp.Count; i++)
            {
                if (tmp.SearchByNumber(i) >= prev)
                {
                    prev = tmp.SearchByNumber(i);
                } else
                {
                    ident = false;
                    return ident;
                }
            }
            return ident;
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
                    Console.WriteLine("1.Заполнить список случайными числами, вывести его на экран и проверить, упорядочены ли в нём элементы по возрастанию");
                    Console.WriteLine("2.Использовать базовые значения в списке и проверить работу метода на нём");
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
                                    DoublyLinkedList<int> s = Input(N);
                                    Console.WriteLine("Текущий список {0}", s.ToString());
                                    if (CheckForIncreasing(s) == true)
                                        Console.WriteLine("Элементы в списке упорядочены по возрастанию");
                                    else Console.WriteLine("Элементы в списке НЕ упорядочены по возрастанию");
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
                                DoublyLinkedList<int> s1 = new DoublyLinkedList<int>();
                                #region [добавление элементов]
                                s1.AddLast(5);
                                s1.AddLast(6);
                                s1.AddLast(7);
                                s1.AddLast(8);
                                s1.AddLast(2);
                                #endregion
                                Console.WriteLine("Базовый список для просмотра работы метода {0}", s1.ToString());
                                if (CheckForIncreasing(s1) == true)
                                    Console.WriteLine("Элементы в списке упорядочены по возрастанию");
                                else Console.WriteLine("Элементы в списке НЕ упорядочены по возрастанию");
                                    break;
                            }
                        default: break;
                    }
                    // приостанавливаем выполнение текущего потока на заданное число времени. Время измеряется в миллисекундах
                    System.Threading.Thread.Sleep(10000); // 10 сек.
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
