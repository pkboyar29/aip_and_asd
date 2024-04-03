using System;

namespace DoublyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DoublyLinkedList<int> s = new DoublyLinkedList<int>();
                s.AddLast(2);
                s.AddLast(3);
                s.AddLast(4);
                Console.WriteLine(s.SearchByValue(5));
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
