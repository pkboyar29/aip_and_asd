using System;

namespace lab7_9_19
{
    class Program
    {
        public static singly<int> Input(int N)
        {
            singly<int> tmp = new singly<int>();
            Random rnd = new Random();
            for (int i = 0; i < N; i++)
            {
                tmp.AddLast(rnd.Next(8));
            }
            return tmp;
        }

        // lab7-9 Вставить в список новый элемент Е1 перед каждым вхождением элемента Е
        public static void AddE1BeforeE(singly<int> tmp, int E, int E1)
        {
            // запускаем цикл, который будет срабатывать столько же раз, сколько и элементов в списке; с помощью i будем фиксировать номер текущего элемента
            for (int i = 1; i < tmp.Count; i++)
            {
                // запоминаем в elem текущий элемент (сначал номер 1, потом последний элемент)
                int elem = tmp.SearchByNumber(i);
                // сравниваем его с E
                if (elem == E)
                {
                    // если они равны, добавляем перед текущим элементов (который равен E и у которого номер i) E1
                    tmp.AddBefore(i, E1);
                    // i увеличиваем на 1, так как мы будем попадать в бесконечный цикл, после добавления элемента, i будет всегда падать на то же число E => всегда до бесконечности перед ним будет добавляться E1
                    i++;
                }
            }
        }

        // lab7-19 Добавить в конец списка все его элементы в обратном порядке
        public static void AddAtEndReverse(singly<int> tmp)
        {
            // запоминаем в count кол-во элементов списка
            int count = tmp.Count;
            // цикл срабатывает столько раз, сколько элементов в списке; начинается работа цикла с последнего элемента списка, так мы сможем обратиться именно к нему и сразу его добавить в конец, а в конце работы цикла в конец списка добавить уже первый элемент
            for (int i = count; i > 0; i--)
            {
                // добавляем в конец элемент по номеру i (от последнего эл-та до первого)
                tmp.AddLast(tmp.SearchByNumber(i));
            }
        }
        static void Main(string[] args)
        {
            try
            {
                ConsoleKeyInfo K;
                singly<int> s = new singly<int>();
                do
                {
                    Console.Clear();
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
                    Console.WriteLine("F3. Вставить в список новый элемент Е1 перед каждым вхождением элемента Е");
                    Console.WriteLine("F4. Добавить в конец списка все его элементы в обратном порядке");
                    Console.WriteLine("Esc. Выход из программы");
                    K = Console.ReadKey();
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
                                } else
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
                                } else
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
                                    } else
                                    {
                                        Console.WriteLine("Элемент НЕ найден");
                                    }
                                } else
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
                                } else
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
                                } else
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
                                } else
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
                                Console.Write("Введите E: ");
                                string txt = Console.ReadLine();
                                int E;
                                Console.Write("Введите E1: ");
                                string txt1 = Console.ReadLine();
                                int E1;
                                if (int.TryParse(txt, out E) && int.TryParse(txt1, out E1))
                                {
                                    AddE1BeforeE(s, E, E1);
                                    Console.WriteLine("Перед каждым вхождением элемента E был вставлен новый элемент E1: {0}", s.ToString());
                                } else
                                {
                                    Console.WriteLine("Неправильный ввод данных");
                                }
                                break;
                            }
                        case ConsoleKey.F4:
                            {
                                Console.WriteLine();
                                AddAtEndReverse(s);
                                Console.WriteLine("В конец списка были добавлены все его элементы в обратном порядке: {0}", s.ToString());
                                break;
                            }
                        default: break;
                    }
                    System.Threading.Thread.Sleep(8500);
                }
                while (K.Key != ConsoleKey.Escape);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
