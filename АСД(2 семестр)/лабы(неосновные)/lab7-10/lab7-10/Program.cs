using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// lab7-10 Оставить в списке только первые вхождения одинаковых элементов

namespace lab7_10
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
        /// оставляет в списке только первые вхождения одинаковых элементов
        /// </summary>
        /// <param name="tmp"></param>
        public static void Delete(singly<int> tmp)
        {
            // наш флаг, с помощью которого мы будем проверять, первое ли у нас вхождение одинакового или нет
            bool flag = true;
            // просто запоминаем количество элементов листа в переменную
            int count = tmp.Count;
            // проходим по каждому элементу листа
            for (int i = 1; i < count; i++)
            {
                // запоминаем в элемент m число, которое мы будем сравнивать с каждым остальным, SearchByNumber возвращает элемент по его номеру, тут номер i (т.е.сначала 1 элемент, потом 2 элемент и т.д.) 
                int m = tmp.SearchByNumber(i);
                // при true будет первое вхождение, при false второе и последующие, т.е. каждый раз перед проходом по каждому элементом мы должны делать flag = true
                flag = true;
                // снова проходим по листу, только теперь мы знаем число, с которым мы будем сравнивать (это m)
                for (int j = 0; j < count; j++)
                {
                    // в переменную h запоминаем удалённый с начала листа элемент, потом мы этот элемент будем сравнивать с m, и затем обратно добавлять его только уже в конец листа (AddLast), ну или ничего не будем делать (т.е. по факту удалим его)
                    int h = tmp.DelFirst();
                    // для второго и последующих вхождениях одинаковых элементов (флаг уже false ==> это у нас не первое вхождение ==> мы не добавляем элемент в конец, т.е. фактически удаляем его, при этом количество элементов в списке будет уменьшенным на 1, поэтому count уменьшаем на 1 (иначе потом с этим будут проблемы), а также j уменьшаем на 1 (иначе потом с этим тоже будут проблемы)
                    if (h == m && flag == false)
                    {
                        j--;
                        count--;
                    }
                    // для первого вхождения одинакового элемента (добавляем его в конец, а также изменяем флаг на false (при flag = false и h = m мы удаляем наш элемент, т.к. это уже второе и последующие вхождения))
                    else if (h == m && flag == true)
                    {
                        flag = false;
                        tmp.AddLast(h);
                        // если у нас элемент не одинаковый (просто добавляем его в конец)
                    } else
                    {
                        tmp.AddLast(h);
                    }
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
                    Console.WriteLine("1.Заполнить список случайными числами, вывести его на экран и оставить в нём только первые вхождения одинаковых элементов");
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
                                    Delete(s);
                                    Console.WriteLine("В списке были оставлены только первые вхождения одинаковых элементов {0}", s.ToString());
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
                                Console.WriteLine("Базовый список для просмотра работы метода {0}", s1.ToString());
                                Delete(s1);
                                Console.WriteLine("В списке были оставлен только первые вхождения одинаковых элементов {0}", s1.ToString());
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
