using System;
using System.Collections;
namespace stacks
// 
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Введите количество элементов стека: ");
                string txt = Console.ReadLine();
                int N;
                if (!int.TryParse(txt, out N) || N <= 0)
                {
                    Console.WriteLine("Введено не натуральное число!");
                } else
                {
                    Stack s = stacks.Input(N);
                    stacks.Output(s);
                    s = stacks.EveryTwo(s);
                    Console.WriteLine();
                    stacks.Output(s);
                }
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
