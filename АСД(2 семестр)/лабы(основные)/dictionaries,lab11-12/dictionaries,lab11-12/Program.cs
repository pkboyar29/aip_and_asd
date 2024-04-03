using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dictionaries_lab11_12
{
    internal class Program
    {
        public static Dictionary<int, string> MyDic(int i)
        {
            Dictionary<int, string> dic = new Dictionary<int, string>();
            Console.WriteLine("Введите имя сотрудника: \n");
            string s;
            for (int j = 0; j < i; j++)
            {
                Console.Write("Name{0} --> ", j);
                s = Console.ReadLine();
                dic.Add(j, s);
                Console.Clear();
            }
            return dic;
        }
        static void Main(string[] args)
        {
            // 1 способ вывода
            Dictionary<int, string> dic = MyDic(5);
            foreach(KeyValuePair<int, string> x in dic)
            {
                Console.WriteLine("{0} - {1}", x.Key, x.Value);
            }

            Console.WriteLine();

            // 2 способ вывода
            ICollection<int> keys = dic.Keys;
            foreach(int j in keys)
            {
                Console.WriteLine("{0} - {1}", j, dic[j]);
            }

            Console.ReadLine();
        }
    }
}
