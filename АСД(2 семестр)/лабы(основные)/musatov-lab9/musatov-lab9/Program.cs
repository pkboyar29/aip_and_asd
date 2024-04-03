using System;
using System.Linq;
//вариант обхода - ПЛК
//lab9-18 В созданном дереве найти минимальный элемент бинарного дерева и количество повторений минимального элемента в данном дереве.
//lab9-24 В бинарном дереве у каждой его вершины, имеющей только одну любую дочернюю вершину, добавить еще одну дочернюю вершину-лист, значение которой должно быть равно удвоенному значению родительской вершины

namespace musatov_lab9
{
    class Program
    {
        static BinaryTree<int> Create_Tree(int N)
        {
            BinaryTree<int> new_tree = new BinaryTree<int>();
            Random rnd = new Random();
            for (int i = 0; i < N; i++)
            {
                new_tree.Add(rnd.Next(5));
            }
            return new_tree;
        }

        static int FindMinElement(BinaryTree<int> tree)
        {
            string[] treeList = tree.BFS().Split(' ');
            int min = int.MaxValue;
            for (int i = 0; i < treeList.Length - 1; i++)
            {
                if (int.Parse(treeList[i]) < min)
                {
                    min = int.Parse(treeList[i]);
                }
            }
            return min;
        }

        static int FindCountOfMinElements(BinaryTree<int> tree)
        {
            int count = 0;
            int min = FindMinElement(tree);
            string[] treeList = tree.BFS().Split(' ');
            for (int i = 0; i < treeList.Length - 1; i++)
            {
                if (int.Parse(treeList[i]) == min)
                {
                    count++;
                }
            }
            return count;
        }

        static void AddDoubledParent(BinaryTree<int> tree)
        {
            string[] treeList = tree.BFS().Split(' ');
            for (int i = 0; i < treeList.Length - 1; i++)
            {
                int node = int.Parse(treeList[i]);
                tree.AddDoubledParent(node, node * 2);
            }
        }
        static void Main(string[] args)
        {
            // создать объект пользовательского класса
            ConsoleKeyInfo K;
            BinaryTree<int> tree = new BinaryTree<int>();
                do
                {
                    Console.Clear(); //очистка экрана перед выводом меню
                    Console.WriteLine("1.Заполнить дерево случайными значениями");
                    Console.WriteLine("2.Добавить узел дерева");
                    Console.WriteLine("3.Вывести дерево на экран с помощью обхода в глубину право-лево-корень");
                    Console.WriteLine("4.Удалить узел дерева");
                    Console.WriteLine("5.lab9-18 В созданном дереве найти минимальный элемент бинарного дерева и количество повторений минимального элемента в данном дереве.");
                    Console.WriteLine("6.lab9-24 В бинарном дереве у каждой его вершины, имеющей только одну любую дочернюю вершину, добавить еще одну дочернюю вершину - лист, значение которой должно быть равно удвоенному значению родительской вершины");
                    Console.WriteLine("Esc. Выход из программы");
                    K = Console.ReadKey();
                    switch (K.Key)
                    {
                        case ConsoleKey.D1:
                            {
                                Console.WriteLine();
                                Console.Write("Введите количество элементов дерева: ");
                                string str = Console.ReadLine();
                                int N;
                                if (int.TryParse(str, out N))
                                {
                                    tree = Create_Tree(N);
                                    Console.WriteLine("Дерево было заполнено случайными значениями");
                                }
                                else
                                {
                                    Console.WriteLine("Неправильный ввод данных");
                                }
                                break;
                            }
                        case ConsoleKey.D2:
                            {
                                Console.WriteLine();
                                Console.Write("Введите значение узла, которое вы хотите добавить: ");
                                string str = Console.ReadLine();
                                int num;
                                if (int.TryParse(str, out num))
                                {
                                    tree.Add(num);
                                    Console.WriteLine("Узел дерева был успешно добавлен");
                                } else
                                {
                                    Console.WriteLine("Неправильный ввод данных");
                                }
                                break;
                            }
                        case ConsoleKey.D3:
                            {
                                Console.WriteLine();
                                Console.WriteLine();
                                tree.Obhod();
                                Console.WriteLine("Дерево было выведено на экран с помощью обхода право-лево-корень");
                                break;
                            }
                        case ConsoleKey.D4:
                            {
                                Console.WriteLine();
                                Console.Write("Введите значение узла, которое вы хотите удалить: ");
                                string str = Console.ReadLine();
                                int num;
                                if (int.TryParse(str, out num))
                                {
                                try
                                {
                                    tree.Del(num);
                                    Console.WriteLine("Узел дерева был успешно удалён");
                                }
                                catch (Exception e) { Console.WriteLine(e.Message); }
                            }
                                else
                                {
                                    Console.WriteLine("Неправильный ввод данных");
                                }
                                break;
                            }
                        case ConsoleKey.D5:
                            {
                                Console.WriteLine();
                                Console.WriteLine("Минимальный элемент дерева: {0}", FindMinElement(tree));
                                Console.WriteLine("Количество минимальных элементов в дереве: {0}", FindCountOfMinElements(tree));
                                break;
                            }
                        case ConsoleKey.D6:
                            {
                                AddDoubledParent(tree);
                                Console.WriteLine("Узлы были успешно добавлены");
                                break;
                            }
                        default: break;
                    }
                    System.Threading.Thread.Sleep(3000);
                }
                while (K.Key != ConsoleKey.Escape);
        }
    }
}
