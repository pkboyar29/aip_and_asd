using System;
using System.Diagnostics;

namespace Musatov_3lab_true_
{
    class Program
    {
        /// <summary>
        /// Метод сортировки массива по возрастанию, без сортировки интерполяционный поиск не будет работать
        /// </summary>
        /// <param name="A"></param>
        static void Bubble(int[] A)
        {
            int temp;
            for (int i = 0; i < A.Length - 1; i++)
            {
                for (int j = A.Length - 2; j >= i; j--)
                    if (A[j] > A[j + 1])
                    {
                        temp = A[j];
                        A[j] = A[j + 1];
                        A[j + 1] = temp;
                    }
            }
        }

        /// <summary>
        /// Заполняет массив случайными числами
        /// </summary>
        /// <param name="arr"></param>
        static void Input(int[] arr)
        {
            Random rnd = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(-100000, 100000);
            }
        }
        /// <summary>
        /// Выводит массив на экран
        /// </summary>
        /// <param name="arr"></param>
        static void Output(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("{0} ", arr[i]);
            }
            Console.WriteLine();
        }
        /// <summary>
        /// Интерполяционный поиск
        /// </summary>
        /// <param name="x"></param>
        /// <param name="a"></param>
        static void interpolationSearch(int search_item, int[] arr)
            // вместо сравнения каждого элемента с искомым при линейном поиске, данный алгоритм производит предсказание местонахождения элемента
        {
            int low = 0; // минимальный индекс массива (левый)
            int high = arr.Length - 1; // максимальный индекс массива (правый)
            while (low <= high)
            {
                int mid = (low + high) / 2; // определяется индекс по формуле линейной интерполяции. получаем элемент по этому индексу, который сравниваем с искомым:
                if (search_item < arr[mid]) // элемент больше искомого, сдвигаем правый элемент ( -1 ) 
                    high = mid - 1;
                else if (search_item > arr[mid]) // элемент меньше искомого, сдвигаем левый элемент ( +1)
                    low = mid + 1;
                else if (search_item == arr[mid])
                {
                    Console.WriteLine("Элемент {0} найден на позиции {1}", search_item, mid + 1);
                    return;
                }
            }
            Console.WriteLine("Поиск не успешен");
        }

        static void menu(int[] arr, Stopwatch sWatch)
        {
            bool f = false;
            // создать объект пользовательского класса
            ConsoleKeyInfo K;
            do
            {
                Console.Clear(); //очистка экрана перед выводом меню
                Console.WriteLine("1.Заполнение массива");
                Console.WriteLine("2.поиск элемента в массиве");
                Console.WriteLine("3.вывод массива на экран");
                Console.WriteLine("Esc. Выход из программы");
                K = Console.ReadKey(); //считывание кода вводимой клавиши
                switch (K.Key)
                {
                    case ConsoleKey.D1: // если нажата клавиша с цифрой 1
                        {
                            Input(arr);
                            Console.WriteLine(". Массив заполнен случайными числами от -100000 до 100000");
                            f = true;
                            break;
                        }
                    case ConsoleKey.D2: // если нажата клавиша с цифрой 2
                        {
                            try
                            {
                                if (f)
                                {
                                    Console.WriteLine(". Введите элемент массива");
                                    int N = int.Parse(Console.ReadLine());
                                    Bubble(arr);
                                    sWatch.Start();
                                    interpolationSearch(N, arr);
                                    sWatch.Stop();
                                    TimeSpan tSpan;
                                    tSpan = sWatch.Elapsed;
                                    Console.WriteLine("Затраченное время на поиск:{0}", tSpan);
                                    sWatch.Reset();
                                }
                                else { Console.WriteLine(". Заполните массив через кнопку '1'"); }
                            }
                            catch (Exception e) { Console.WriteLine(e.Message); }
                            break;
                        }
                    case ConsoleKey.D3: // если нажата клавиша с цифрой 3
                        {
                            Bubble(arr);
                            Console.WriteLine(". массив:");
                            Output(arr);
                            break;
                        }
                    default: break;
                }
                // приостанавливаем выполнение текущего потока на заданное число времени. Время измеряется в миллисекундах
                System.Threading.Thread.Sleep(2000); // 2 сек. (2000)
            }
            while (K.Key != ConsoleKey.Escape);// цикл заканчивается, если нажата клавиша Esc
        }
        static void Main(string[] args)
        {
            try
            {
                Stopwatch sWatch = new Stopwatch();
                Console.Write("Введите размерность массива: ");
                string txt = Console.ReadLine();
                int N;
                if (!int.TryParse(txt, out N) || N <= 0)
                {
                    Console.WriteLine("Вы ввели не натуральное число!");
                } else
                {
                    int[] arr = new int[N];
                    menu(arr, sWatch);
                }


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
