using System;
// lab7-16 Удалить из непустого списка за каждым вхождением элемента Е один элемент, если такой есть.
namespace lab7_16
{
    class Program
    {
        /// <summary>
        /// заполняет список случайными значениями
        /// </summary>
        /// <param name="N"></param>
        /// <returns></returns>
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
        /// <summary>
        /// lab7-12 Продублировать каждый элемент списка
        /// </summary>
        /// <param name="tmp"></param>
        public static void Dublicate(singly<int> tmp)
        {
            // проходим по каждому элементу списка
            for (int i = 1; i < tmp.Count + 1; i++)
            {
                tmp.AddAfter(i, tmp.SearchByNumber(i));
                i++;
            }
        }

        /// <summary>
        /// удаляет из списка за каждым вхождением элемента E один элемент
        /// </summary>
        /// <param name="tmp"></param>
        /// <param name="E"></param>
        public static void DeleteAfterE(singly<int> tmp, int E)
        {
            // проходим по всему списку с помощью цикла for
            for (int i = 1; i < tmp.Count ; i++)
            {
                // с помощью SearchByNumber находим элемент с номером i (таким образом с помощью цикла for проходим по всему списку)
                // сравниваем элемент с элементом E, если они равны ==> мы удаляем элемент после него (с помощью DelAfter(i), где i - номер текущего элемента, который равен E)
                if (tmp.SearchByNumber(i) == E)
                {
                    tmp.DelAfter(i);
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
                    Console.WriteLine("1.Заполнить список случайными числами, вывести его на экран и удалить за каждым вхождением элемента E один элемент, если такой есть");
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
                                    singly<int> s = Input(N);
                                    Console.WriteLine("Текущий список {0}", s.ToString());
                                    Console.Write("Введите элемент E: ");
                                    string txt1 = Console.ReadLine();
                                    int E;
                                    if (int.TryParse(txt1, out E))
                                    {
                                        //Dublicate(s);
                                        DeleteAfterE(s, E);
                                        Console.WriteLine("За каждым вхождением элемента E в списке удалён один элемент: {0}", s.ToString());
                                    } else
                                    {
                                        Console.WriteLine("Неправильный ввод данных");
                                    }
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
                                singly<int> s1 = new singly<int>();
                                s1.AddLast(1);
                                s1.AddLast(2);
                                s1.AddLast(1);
                                s1.AddLast(8);
                                s1.AddLast(5);
                                s1.AddLast(10);
                                s1.AddLast(1);
                                s1.AddLast(1);
                                s1.AddLast(8);
                                s1.AddLast(5);
                                s1.AddLast(8);
                                Console.WriteLine("Базовый список для просмотра работы метода:  {0}", s1.ToString());
                                Console.WriteLine("Базовый элемент E: 8");
                                DeleteAfterE(s1, 8);
                                Console.WriteLine("За каждым вхождением элемента E в списке удалён один элемент: {0}", s1.ToString());
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
