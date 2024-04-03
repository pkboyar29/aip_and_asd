using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace musatov_lab9
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
        private Element Find(T a)
        {
            Element q = Root;
            Element tmp = q;
            while (tmp != null)
            {
                if (tmp.CompareTo(a) <= 0)
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
                Element q = Find(a);
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
            if (nodes[1] == null) throw new Exception("Значение узла не найдено");
            // 1.удаление листа
            if (nodes[1].Left == null && nodes[1].Right == null)
            {
                if (nodes[1] != Root)
                {
                    if (nodes[0].CompareTo(nodes[1].Data) < 0)
                        nodes[0].Right = null;
                    else
                        nodes[0].Left = null;
                }
                else
                    Root = null;
            }
            // 2.удаление узла, у которго ТОЛЬКО правый элемент не пустой
            else if (nodes[1].Left == null && nodes[1].Right != null)
            {
                if (nodes[1] != Root)
                {
                    if (nodes[0].CompareTo(nodes[1].Data) < 0)
                        nodes[0].Right = nodes[1].Right;
                    else nodes[0].Left = nodes[1].Right;
                }
                else
                    Root = nodes[1].Right;
                
            }
            // 3.удаление узла, у которго ТОЛЬКО левый элемент не пустой
            else if (nodes[1].Left != null && nodes[1].Right == null)
            {
                if (nodes[1] != Root)
                {
                    if (nodes[0].CompareTo(nodes[1].Data) < 0)
                        nodes[0].Right = nodes[1].Left;
                    else nodes[0].Left = nodes[1].Left;
                }
                else 
                    Root = nodes[1].Left;
            }
            // 4.удаление узла, у которого оба потомка не пусты
            else if (nodes[1].Left != null && nodes[1].Right != null)
            {
                if (nodes[1].Right.Left == null)
                {
                    nodes[1].Data = nodes[1].Right.Data;
                    nodes[1].Right = nodes[1].Right.Right;
                }
                else
                {
                    Element[] d = FindMin(nodes[1].Right);
                    if (d[1].Right == null)
                    {
                        nodes[1].Data = d[1].Data;
                        d[0].Left = null;
                    }
                    else
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

        public void AddDoubledParent(T a, T b)
        {
            Element[] nodes = Poisk(a);
            if (nodes[1].Left == null && nodes[1].Right != null)
            {
                Element q = new Element(b);
                nodes[1].Left = q;
            }
            else if (nodes[1].Left != null && nodes[1].Right == null)
            {
                Element q = new Element(b);
                nodes[1].Right = q;
            }
        }

        /// <summary>
        /// обход в глубину
        /// </summary>
        public void Obhod()
        {
            Element q = Root;
            Write(q);
        }
        /// <summary>
        /// право-лево-корень
        /// </summary>
        /// <param name="q"></param>
        private void Write(Element q)
        {
            if (q != null)
            {
                Write(q.Right);
                Write(q.Left);
                Console.WriteLine(q.Data);
            }
        }
        /// <summary>
        /// обход в ширину
        /// </summary>
        /// <returns></returns>
        public string BFS()
        {
            string s = string.Empty;
            if (Root != null)
            {
                Queue q = new Queue();
                Element tmp = Root;
                q.Enqueue(tmp);
                do
                {
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
