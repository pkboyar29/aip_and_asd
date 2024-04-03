using System;
// lab8-15 Вставить после каждого элемента, занимающего четную позицию в списке, новый элемент Е1
namespace lab8_15
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

        public static void AddE1AfterEvenPos(doubly<int> tmp, int E1)
        {
            // с помощью флага ident будем определять, когда мы находимся на чётной позиции элемента списка (это каждый второй, изначально false - это значит, что мы находимся на нечётной позиции; true - на каждой чётной позиции)
            bool ident = false;
            // проходим по списку
            for (int i = 1; i < tmp.Count + 1; i++)
            {
                // если чётная позиция, добавляем элемент E1 после этого номера i; затем i увеличиваем на 1, так как иначе следующий i будет падать на E1, а мы должны продолжать дальше со списком
                if (ident == true)
                {
                    tmp.AddAfter(i, E1);
                    i++;
                    ident = false;
                } else
                {
                    ident = true;
                }
            }
        }

        static void Main(string[] args)
        {
            try
            {
                // создать объект пользовательского класса
                ConsoleKeyInfo K;
                doubly<int> s = new doubly<int>();
                do
                {
                    Console.Clear(); //очистка экрана перед выводом меню
                    Console.WriteLine("1.Заполнить список случайным значениями и вывести его на экран");
                    Console.WriteLine("2.Добавить после каждого элемента с чётной позицией элемент E1");
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
                                    s = Input(N);
                                    Console.WriteLine("Текущий список {0}", s.ToString());
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
                                if (s.Count == 0)
                                {
                                    Console.WriteLine("Список не заполнен");
                                } else
                                {
                                    Console.WriteLine("Текущий список {0}", s.ToString());
                                    Console.Write("Введите E1: ");
                                    string txt1 = Console.ReadLine();
                                    int E1;
                                    if (int.TryParse(txt1, out E1))
                                    {
                                        AddE1AfterEvenPos(s, E1);
                                        Console.WriteLine("После каждого элемента списка с чётной позицией добавлен элемент E1: {0}", s.ToString());
                                    }
                                    else
                                    {
                                        Console.WriteLine("Неправильный ввод данных");
                                    }
                                }
                                break;
                            }
                        default: break;
                    }
                    // приостанавливаем выполнение текущего потока на заданное число времени. Время измеряется в миллисекундах
                    System.Threading.Thread.Sleep(6000); // 6 сек.
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
