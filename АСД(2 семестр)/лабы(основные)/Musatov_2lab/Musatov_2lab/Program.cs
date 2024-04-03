using System;
using System.Diagnostics;

namespace Musatov_2lab
{
    class Program
    {
        /// <summary>
        /// Заполняет массив случайными числами
        /// </summary>
        /// <param name="arr"></param>
        static void Input(int[] arr)
        {
            Random rnd = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(-50, 50);
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
        /// Метод сортировки массива "пузырьком"
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
        //проход снизу вверх по массиву, по пути рассматриваются пары соседних элементов
        //Если элементы некоторой пары находятся в неправильном порядке, то меняем их местами.
        //после нулевого прохода в начале массива оказывается самый маленький элемент
        //в конце прохода наименьший элемент перемещается на одну позицию к началу массива,
        //а наибольший элемент перемещается на одну позицию вправо

        /// <summary>
        /// Метод Шелла
        /// </summary>
        /// <param name="arr"></param>
        static void Shel(int[] arr)
        {

            int temp = 0;
            int N = arr.Length;
            int K = N / 2; // коэффициент, с помощью которого работает сортировка Шелла
            while (K >= 1) // когда шаг меньше 1, то заканчиваем работу метода; последняя проходка происходит с K = 1
            {
                K = K / 2; // с каждым шагом мы должны уменьшить наш коэффициент вдвое
                for (int i = 0; i < N-K; i++)
                {
                    if (arr[i] > arr[i + K])
                    {
                        temp = arr[i + K];
                        arr[i + K] = arr[i];
                        arr[i] = temp;
                    }
                    for (int j = 0; j <= i; j++) 
                    {
                        if (arr[j] > arr[j + K])
                        {
                            temp = arr[j + K];
                            arr[j + K] = arr[j];
                            arr[j] = temp;
                        }
                    }
                }
            }
        }
        /*сравниваются элементы, расположенные на расстоянии K и, если они неупорядочены, то
          меняются метами; после каждого просмотра шаг уменьшается вдвое, пока не станет =1;*/
/* сортировка иногда требует возврата назад и проверки того, отсортированы ли элементы по этому коэффициенту, 
 * поэтому, добавив еще один цикл for, мы можем снова выполнить цикл для прошлых элементов в массиве */
static void Main(string[] args)
{
    try
    {
        Stopwatch sWatch = new Stopwatch();
        Console.Write("Введите натуральное число N: ");
        string txt = Console.ReadLine();
        int N;
        if (!int.TryParse(txt, out N) || N <= 0)
        {
            Console.WriteLine("Вы ввели не натуральное число!");
        }
        else
        {
            int[] arr = new int[N];
            Input(arr);
            int[] arrcopy1 = new int[N];
            Array.Copy(arr, arrcopy1, N);
            int[] arrcopy2 = new int[N];
            Array.Copy(arr, arrcopy2, N);
            ConsoleKeyInfo K; // описывает нажатую клавишу консоли
            do
            {
                Console.Clear();
                Console.WriteLine("1.Метод пузырьком");
                Console.WriteLine("2.Метод Шелла");
                Console.WriteLine("Esc. Выход из программы");
                K = Console.ReadKey();
                switch (K.Key)
                {
                    case ConsoleKey.D1: // если нажата клавиша с цифрой 1
                        {
                            Console.WriteLine();
                            //Output(arr);
                            sWatch.Start();
                            Bubble(arrcopy1);
                            //Output(arrcopy1);
                            sWatch.Stop();
                            Array.Copy(arr, arrcopy1, N);
                            TimeSpan tSpan1;
                            tSpan1 = sWatch.Elapsed;
                            Console.WriteLine(tSpan1.ToString());
                            break;
                        }
                    case ConsoleKey.D2: // если нажата клавиша с цифрой 2
                        {
                            Console.WriteLine();
                            //Output(arr);
                            sWatch.Start();
                            Shel(arrcopy2);
                            //Output(arrcopy2);
                            sWatch.Stop();
                            Array.Copy(arr, arrcopy2, N);
                            TimeSpan tSpan2;
                            tSpan2 = sWatch.Elapsed;
                            Console.WriteLine(tSpan2.ToString());
                            break;
                        }
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Вы ввели что-то не то!"); 
                        break;
                }
                // приостанавливаем выполнение текущего потока на заданное число времени.
                // Время измеряется в миллисекундах
                System.Threading.Thread.Sleep(6000); // 6 сек
            }
            while (K.Key != ConsoleKey.Escape); // цикл заканчивается, если нажата клавишу Esc

        }


        } catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}
}
}