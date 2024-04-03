using System;

namespace lab8_12_24
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

        /// <summary>
        /// lab8-12 Продублировать каждый элемент списка
        /// </summary>
        /// <param name="tmp"></param>
        public static void Dublicate(doubly<int> tmp)
        {
            for (int i = 1; i < tmp.Count + 1; i++)
            {
                // добавляем после текущего элемента (с номером i) этот же элемент (тоже номер i)
                tmp.AddAfter(i, tmp.SearchByNumber(i));
                i++;
            }
        }

        /// <summary>
        /// сортирует список по возрастанию
        /// </summary>
        /// <param name="tmp"></param>
        public static void Sort(doubly<int> tmp)
        {
            // создаём доп список
            doubly<int> tmp1 = new doubly<int>();
            // опустошаем основной список и сортируем все в доп списке по убыванию
            while (tmp.Count != 0)
            {
                int poppedElement = (int)tmp.DelFirst();
                while (tmp1.Count != 0 && poppedElement < (int)tmp1.SearchByNumber(1))
                {
                    tmp.AddFirst(tmp1.DelFirst());
                }
                tmp1.AddFirst(poppedElement);
            }
            // закидываем всё обратно и снова переворачиваем (уже по возрастанию)
            while (tmp1.Count != 0)
            {
                tmp.AddFirst(tmp1.DelFirst());
            }
        }

        /// <summary>
        /// lab8-24 Вставить в непустой список, элементы которого упорядочены по возрастанию, новый элемент так, чтобы сохранилась упорядоченность
        /// </summary>
        /// <param name="tmp"></param>
        /// <param name="E"></param>
        public static void AddElemWithOrderliness(doubly<int> tmp, int E)
        {
            for (int i = 1; i < tmp.Count + 1; i++)
            {
                // если собстна наш элемент меньше или равен текущему элементу, то ему как раз место вставать перед этим элементом, что мы и делаем
                if (E <= tmp.SearchByNumber(i))
                {
                    tmp.AddBefore(i, E);
                    break;
                }
                // если элемент самый большой, рассматриваем для него случай и закидываем его в конец
                if (i == tmp.Count)
                {
                    tmp.AddLast(E);
                    break;
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
                    Console.WriteLine("0. Заполнить список случайными значениями");
                    Console.WriteLine("1. Добавить элемент в начало списка");
                    Console.WriteLine("2. Добавить элемент в конец списка");
                    Console.WriteLine("3. Вывести список на экран в прямом и обратном порядке");
                    Console.WriteLine("4. Найти элемент по его значению (возвращает bool)");
                    Console.WriteLine("5. Найти элемент по его номеру (возвращает значение)");
                    Console.WriteLine("6. Добавить элемент перед заданным");
                    Console.WriteLine("7. Добавить элемент после заданного");
                    Console.WriteLine("8. Удалить элемент из начала списка");
                    Console.WriteLine("9. Удалить элемент из конца списка");
                    Console.WriteLine("F1. Удалить элемент перед заданным");
                    Console.WriteLine("F2. Удалить элемент после заданным");
                    Console.WriteLine("F3. Продублировать каждый элемент списка");
                    Console.WriteLine("F4. Вставить в непустой список, элементы которого упорядочены по возрастанию, новый элемент так, чтобы сохранилась упорядоченность");
                    Console.WriteLine("Esc. Выход из программы");
                    K = Console.ReadKey(); //считывание кода вводимой клавиши
                    switch (K.Key)
                    {
                        case ConsoleKey.D0:
                            {
                                Console.WriteLine();
                                Console.Write("Введите количество элементов списка: ");
                                string txt = Console.ReadLine();
                                int N;
                                if (int.TryParse(txt, out N))
                                {
                                    s = Input(N);
                                    Console.WriteLine("Список заполнен случайными значениями");
                                }
                                else
                                {
                                    Console.WriteLine("Неправильный ввод данных");
                                }
                                break;
                            }
                        case ConsoleKey.D1:
                            {
                                Console.WriteLine();
                                Console.Write("Введите элемент, который вы хотите добавить в начало списка: ");
                                string txt = Console.ReadLine();
                                int elem;
                                if (int.TryParse(txt, out elem))
                                {
                                    s.AddFirst(elem);
                                    Console.WriteLine("В начало списка добавлен элемент: {0}", s.ToString());
                                }
                                else
                                {
                                    Console.WriteLine("Неправильный ввод данных");
                                }
                                break;
                            }
                        case ConsoleKey.D2:
                            {
                                Console.WriteLine();
                                Console.Write("Введите элемент, который вы хотите добавить в конец списка: ");
                                string txt = Console.ReadLine();
                                int elem;
                                if (int.TryParse(txt, out elem))
                                {
                                    s.AddLast(elem);
                                    Console.WriteLine("В конец списка добавлен элемент: {0}", s.ToString());
                                }
                                else
                                {
                                    Console.WriteLine("Неправильный ввод данных");
                                }
                                break;
                            }
                        case ConsoleKey.D3:
                            {
                                Console.WriteLine();
                                Console.WriteLine("Список в прямом порядке: {0}", s.ToString());
                                Console.WriteLine("Список в обратном порядке: {0}", s.OutputReverse());
                                break;
                            }
                        case ConsoleKey.D4:
                            {
                                Console.WriteLine();
                                Console.Write("Какой элемент вы хотите найти в списке: ");
                                string txt = Console.ReadLine();
                                int elem;
                                if (int.TryParse(txt, out elem))
                                {
                                    if (s.SearchByValue(elem))
                                    {
                                        Console.WriteLine("Элемент найден");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Элемент НЕ найден");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Неправильный ввод данных");
                                }
                                break;
                            }
                        case ConsoleKey.D5:
                            {
                                Console.WriteLine();
                                Console.Write("По какому номеру необходимо найти элемент в списке: ");
                                string txt = Console.ReadLine();
                                int i;
                                if (int.TryParse(txt, out i) && i > 0)
                                {
                                    Console.WriteLine("По номеру {0} найден элемент {1}", i, s.SearchByNumber(i));
                                }
                                else
                                {
                                    Console.WriteLine("Неправильный ввод данных");
                                }
                                break;
                            }
                        case ConsoleKey.D6:
                            {
                                Console.WriteLine();
                                Console.Write("Введите номер элемента, перед которым будет добавлен элемент: ");
                                string txt = Console.ReadLine();
                                Console.Write("Введите элемент, который будет добавлен перед заданным: ");
                                string txt1 = Console.ReadLine();
                                int N;
                                int N1;
                                if (int.TryParse(txt, out N) && int.TryParse(txt1, out N1) && N > 0)
                                {
                                    s.AddBefore(N, N1);
                                    Console.WriteLine("Перед заданным элементом был добавлен элемент {0}: {1}", N1, s.ToString());
                                }
                                else
                                {
                                    Console.WriteLine("Неправильный ввод данных");
                                }
                                break;
                            }
                        case ConsoleKey.D7:
                            {
                                Console.WriteLine();
                                Console.Write("Введите номер элемента, после которого будет добавлен элемент: ");
                                string txt = Console.ReadLine();
                                Console.Write("Введите элемент, который будет добавлен после заданного: ");
                                string txt1 = Console.ReadLine();
                                int N;
                                int N1;
                                if (int.TryParse(txt, out N) && int.TryParse(txt1, out N1) && N > 0)
                                {
                                    s.AddAfter(N, N1);
                                    Console.WriteLine("После заданного элемента был добавлен элемент {0}: {1}", N1, s.ToString());
                                }
                                else
                                {
                                    Console.WriteLine("Неправильный ввод данных");
                                }
                                break;
                            }
                        case ConsoleKey.D8:
                            {
                                Console.WriteLine();
                                s.DelFirst();
                                Console.WriteLine("Удалён элемент в начале списка: {0}", s.ToString());
                                break;
                            }
                        case ConsoleKey.D9:
                            {
                                Console.WriteLine();
                                s.DelLast();
                                Console.WriteLine("Удалён элемент в конце списка: {0}", s.ToString());
                                break;
                            }
                        case ConsoleKey.F1:
                            {
                                Console.WriteLine();
                                Console.Write("Введите номер элемента, перед которым будет удалён элемент: ");
                                string txt = Console.ReadLine();
                                int i;
                                if (int.TryParse(txt, out i) && i > 0)
                                {
                                    s.DelBefore(i);
                                    Console.WriteLine("Перед заданным элементом удалён элемент:  {0}", s.ToString());
                                }
                                else
                                {
                                    Console.WriteLine("Неправильный ввод данных");
                                }
                                break;
                            }
                        case ConsoleKey.F2:
                            {
                                Console.WriteLine();
                                Console.Write("Введите номер элемента, после которого будет удалён элемент: ");
                                string txt = Console.ReadLine();
                                int i;
                                if (int.TryParse(txt, out i) && i > 0)
                                {
                                    s.DelAfter(i);
                                    Console.WriteLine("После заданного элемента удалён элемент:  {0}", s.ToString());
                                }
                                else
                                {
                                    Console.WriteLine("Неправильный ввод данных");
                                }
                                break;
                            }
                        case ConsoleKey.F3:
                            {
                                Console.WriteLine();
                                Dublicate(s);
                                Console.WriteLine("В списке продублирован каждый элемент: {0}", s.ToString());
                                break;
                            }
                        case ConsoleKey.F4:
                            {
                                Console.WriteLine();
                                Sort(s);
                                Console.WriteLine("Текущий список (уже упорядочен по возрастанию) {0}", s.ToString());
                                Console.Write("Введите E: ");
                                string txt = Console.ReadLine();
                                int E;
                                if (int.TryParse(txt, out E))
                                {
                                    AddElemWithOrderliness(s, E);
                                    Console.WriteLine("В список, который упорядочен по возрастанию, вставлен новый элемент, при этом упорядоченность сохранилась: {0}", s.ToString());
                                } else
                                {
                                    Console.WriteLine("Неправильный ввод данных");
                                }
                                break;
                            }
                        default: break;
                    }
                    // приостанавливаем выполнение текущего потока на заданное число времени. Время измеряется в миллисекундах
                    System.Threading.Thread.Sleep(8500);
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
