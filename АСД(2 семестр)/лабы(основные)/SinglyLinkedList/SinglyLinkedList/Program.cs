using System;

namespace SinglyLinkedListClass
{
    class Program
    {
        public static SinglyLinkedList<int> Input(int N)
        {
            SinglyLinkedList<int> tmp = new SinglyLinkedList<int>();
            Random rnd = new Random();
            for (int i = 0; i < N; i++)
            {
                tmp.AddLast(rnd.Next(12));
            }
            return tmp;
        }
        // Вставить в непустой список новые элементы Е1 и Е2 перед последним элементом списка
        public static void PasteE1E2(int E1, int E2, SinglyLinkedList<int> tmp)
        {
            tmp.AddBefore(tmp.Count, E1);
            tmp.AddBefore(tmp.Count, E2);
        }
        // lab7-4 Удалить из списка все отрицательные элементы
        public static void DeleteAllNegative(SinglyLinkedList<int> tmp)
        {
            int count = tmp.Count;
            for (int i = 1; i <= count; i++)
            {
                if (tmp.SearchByNumber(i) < 0)
                {
                    tmp.Del(i);
                    i--;
                    count--;
                }
            }
        }
        // lab7-5 Перевернуть список, т.е. изменить ссылки в этом списке так, чтобы его элементы оказались расположенными в обратном порядке
        public static void ReverseOfList(SinglyLinkedList<int> tmp)
        {
            int count = tmp.Count;
            for (int i = 1; i < count; i++)
            {
                tmp.AddBefore(i, tmp.DelLast());
            }
        }
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Введите количество элементов списка: ");
                string txt = Console.ReadLine();
                int N;
                if (int.TryParse(txt, out N))
                {
                    SinglyLinkedList<int> s = Input(N);
                    Console.WriteLine(s.ToString());
                    ReverseOfList(s);
                    Console.WriteLine(s.ToString());
                } else
                {
                    Console.WriteLine("Неправильный ввод данных");
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }
}
