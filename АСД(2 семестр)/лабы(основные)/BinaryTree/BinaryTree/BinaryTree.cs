using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace BinaryTree
{
    public class BinaryTree<T>
    {
        public class Element : IComparable<T>
        {
            public T Data { set; get; }
            public Element Left { set; get; }
            public Element Right { set; get; }

            public Element()
            {
            }
            public Element(T a)
            {
                Data = a;
                Left = null;
                Right = null;
            }

            public int CompareTo(T other)
            {
                // TODO ДЛЯ ОТРИЦАТЕЛЬНЫХ ЧИСЕЛ НЕ РАБОТАЕТ
                if (this.Data.ToString().Length < other.ToString().Length)
                    return -1;
                else
                    if (Data.ToString().Length > other.ToString().Length)
                    return +1;
                return Data.ToString().CompareTo(other.ToString());
            }
        }

        Element Root = null;
        /// <summary>
        /// ищет лист дерева, откуда можно добавить элемент в дерево, сохраняя последовательность (нужен для добавления элемента в дерево)
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        private Element FindSheet(T a)
        { 
            Element q = Root;
            Element tmp = q;
            while (tmp != null)
            {
                if (tmp.CompareTo(a) < 0)
                {
                    q = tmp;
                    tmp = tmp.Right;
                }
                else
                {
                    q = tmp;
                    tmp = tmp.Left;
                }
            }
            return q;
        }
        /// <summary>
        /// ищет и возвращает родителя узла определённого значения
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        private Element Find(T a)
        {
            Element q = Root;
            Element tmp = q;
            while (tmp != null && tmp.Data.ToString() != a.ToString())
            {
                if (tmp.CompareTo(a) < 0)
                {
                    q = tmp;
                    tmp = tmp.Right;
                }
                else
                {
                    q = tmp;
                    tmp = tmp.Left;
                }
            }
            return q;
        }
        public void Add(T a)
        {
            if (Root == null)
            {
                Element tmp = new Element(a);
                tmp.Left = null;
                tmp.Right = null;
                Root = tmp;
            }
            else
            {
                Element tmp = new Element(a);
                Element q = FindSheet(a);
                if (tmp.CompareTo(q.Data) < 0) q.Left = tmp;
                else q.Right = tmp;

            }
        }

        /// <summary>
        /// возвращает массив ссылок (0 индекс - родитель узла, который нам надо найти; 1 индекс - узел, который нам надо найти)
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        private Element[] Poisk(T a)
        {
            Element q = Root;
            Element tmp = q;
            while (tmp != null && tmp.CompareTo(a) != 0)
            {
                if (tmp.CompareTo(a) < 0)
                {
                    q = tmp;
                    tmp = tmp.Right;
                }
                else
                {
                    q = tmp;
                    tmp = tmp.Left;
                }
            }
            return new Element[2] { q, tmp };
        }

        public void Del(T el)
        {
            Element[] nodes = Poisk(el);
            if (nodes[1] == null) throw new Exception("Not Found");
            // 1.удаление листа
            if (nodes[1].Left == null && nodes[1].Right == null)
            {
                if (nodes[1] != Root)
                {
                    if (nodes[0].CompareTo(nodes[1].Data) < 0) 
                        nodes[0].Right = null;
                    else 
                        nodes[0].Left = null;
                } else
                    Root = null;
            }
            // 2.удаление узла, у которго ТОЛЬКО правый элемент не пустой
            else if (nodes[1].Left == null && nodes[1].Right != null)
            {
                if (nodes[0].CompareTo(nodes[1].Data) < 0)
                    nodes[0].Right = nodes[1].Right;
                else nodes[0].Left = nodes[1].Right;
            }
            // 3.удаление узла, у которго ТОЛЬКО левый элемент не пустой
            else if (nodes[1].Left != null && nodes[1].Right == null)
            {
                if (nodes[0].CompareTo(nodes[1].Data) < 0)
                    nodes[0].Right = nodes[1].Left;
                else nodes[0].Left = nodes[1].Left;
            }
            // 4.удаление узла, у которого оба потомка не пусты
            else if (nodes[1].Left != null && nodes[1].Right != null)
            {
                if (nodes[1].Right.Left == null)
                {
                    nodes[1].Data = nodes[1].Right.Data;
                    nodes[1].Right = nodes[1].Right.Right;
                } else
                {
                    Element[] d = FindMin(nodes[1].Right);
                    if (d[1].Right == null)
                    {
                        nodes[1].Data = d[1].Data;
                        d[0].Left = null;
                    } else
                    {
                        nodes[1].Data = d[1].Data;
                        d[0].Left = d[1].Right;
                    }
                }
            }
        }
        private Element[] FindMin(Element q)
        {
            Element n = q;
            while (q.Left != null)
            {
                n = q;
                q = q.Left;
            }
            return new Element[2] { n, q };
        }
        // TODO МОЖНО РЕАЛИЗОВАТЬ ПОИСК МАКСИМАЛЬНОГО И МИНИМАЛЬНОГО ПУТИ

        /*private Element FindMinElement(Element node)
        {
            if (node.Left == null)
            {
                return node;
            }
            return this.FindMinElement(node.Left);
        }*/

        /*public T Del(T a)
        {
            if (Root != null)
            {
                Element q = new Element();
                Element tmp = Find(a);
                bool ident;
                if (tmp == Root && Root.Data.ToString() == a.ToString())
                {
                    q = tmp;
                    ident = true;
                } else if (tmp.CompareTo(a) < 0)
                {
                    q = tmp.Right;
                    ident = true;
                } else
                {
                    q = tmp.Left;
                    ident = false;
                }
                if (q.Left == null && q.Right == null)
                {
                    T b = q.Data;
                    if (tmp.CompareTo(a) < 0)
                    {
                        tmp.Right = null;
                    }
                    else
                    {
                        tmp.Left = null;
                    }
                    return b;
                } else if (q.Left == null && q.Right != null)
                {
                    if (ident)
                    {
                        tmp.Right = q.Right;
                    } else
                    {
                        tmp.Left = q.Right;
                    }
                    T b = q.Data;
                    q = null;
                    return b;
                } else if (q.Right == null && q.Left != null)
                {
                    if (ident)
                    {
                        tmp.Right = q.Left;
                    }
                    else
                    {
                        tmp.Left = q.Left;
                    }
                    T b = q.Data;
                    q = null;
                    return b;
                }
                else
                {
                    Element m = FindMinElement(q.Right);
                    T b = m.Data;
                    Del(b);
                    q.Data = b;
                    return b;
                }
            } else
            {
                throw new Exception("Невозможно удалить элемент из пустого дерева");
            }
        }*/

        public void Obhod()
        {
            Element q = Root;
            //WriteLPK(q);
            //WritePLK(q);
            //WriteKLP(q);
            //WriteLKP(q);
            WritePKL(q);
        }
        private void WriteLPK(Element q) // ЛПК
        {
            if (q != null)
            {
                WriteLPK(q.Left);
                WriteLPK(q.Right);
                Console.WriteLine(q.Data);
            }
        }
        private void WritePLK(Element q) // ПЛК
        {
            if (q != null)
            {
                WritePLK(q.Right);
                WritePLK(q.Left);
                Console.WriteLine(q.Data);
            }
        }
        private void WriteKLP(Element q) // КЛП
        {
            if (q != null)
            {
                Console.WriteLine(q.Data);
                WriteKLP(q.Left);
                WriteKLP(q.Right);
            }
        }
        private void WriteLKP(Element q) // ЛКП
        {
            if (q != null)
            {
                WriteLKP(q.Left);
                Console.WriteLine(q.Data);
                WriteLKP(q.Right);
            }
        }
        private void WritePKL(Element q) // ПКЛ
        {
            if (q != null)
            {
                WritePKL(q.Right);
                Console.WriteLine(q.Data);
                WritePKL(q.Left);
            }
        }
        public string BFS()
        {
            string s = string.Empty;
            if (Root != null) {
                Queue q = new Queue();
                Element tmp = Root;
                q.Enqueue(tmp);
                do {
                    tmp = (Element)q.Dequeue();
                    s += tmp.Data.ToString() + " ";
                    if (tmp.Left != null)
                        q.Enqueue(tmp.Left);
                    if (tmp.Right != null)
                        q.Enqueue(tmp.Right);
                }
                while (q.Count != 0);
            }
            return s;
        }
    }
}
