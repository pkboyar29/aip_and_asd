using System;

namespace dequeCLASS
{
    class Program
    {
        static void Main(string[] args)
        {
            Deque<int> s = new Deque<int>();
            s.Push(2);
            s.Push(7);
            s.Push(9);
            s.Push(11);
            s.Push(16);
            Console.WriteLine(s.ToString());
        }
    }
}
