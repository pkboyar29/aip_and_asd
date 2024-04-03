using System;
using System.Collections;

namespace BinaryTree
{
    class Program
    {
        static BinaryTree<int> Create_Tree(int N)
        {
            BinaryTree<int> new_tree = new BinaryTree<int>();
            Random rnd = new Random();
            for (int i = 0; i < N; i++)
            {
                new_tree.Add(rnd.Next(0));
            }
            return new_tree;
        }
        static void Main(string[] args)
        {
            BinaryTree<int> tree = new BinaryTree<int>();
            tree.Add(10);
            tree.Add(100);
            tree.Add(7);
            tree.Add(128);
            tree.Add(55);
            tree.Add(32);
            tree.Add(59);
            tree.Add(112);
            tree.Del(10);
            Console.WriteLine(tree.BFS());
        }
    }
}
