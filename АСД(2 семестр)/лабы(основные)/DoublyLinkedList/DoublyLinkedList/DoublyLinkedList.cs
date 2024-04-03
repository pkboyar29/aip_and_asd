using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace DoublyLinkedList
{
    [System.Runtime.InteropServices.Guid("0F1D00B2-8138-49C3-9401-51DA70F54F72")]
    class DoublyLinkedList<T> : IEnumerable<T>
    {
        private class Element
        {
            public T Data { set; get; }
            public Element Next { set; get; }
            public Element Prev { set; get; }

            public Element()
            {
            }
            public Element(T a)
            {
                Data = a;
                Next = null;
                Prev = null;
            }
        }
        Element Head = null;
        Element Last = null;

        /// <summary>
        /// добавляет элемент в начало списка
        /// </summary>
        /// <param name="a"></param>
        public void AddFirst(T a)
        {
            Element NewNode = new Element(a);
            if (Head == null)
            {
                Head = NewNode;
                Last = Head;
            }
            else
            {
                NewNode.Next = Head;
                Head.Prev = NewNode;
                Head = NewNode;
            }
        }
        /// <summary>
        /// добавляет элемент в конец списка
        /// </summary>
        /// <param name="a"></param>
        public void AddLast(T a)
        {
            Element tmp = new Element(a);

            if (Head != null)
            {
                tmp.Prev = Last;
                Last.Next = tmp;
                Last = tmp;
            }
            else
            {
                Head = tmp;
                Last = tmp;
            }
        }
        /// <summary>
        /// добавляет элемент после номера
        /// </summary>
        /// <param name="i"></param>
        /// <param name="a"></param>
        public void AddAfter(int i, T a)
        {
            Element NewNode = new Element(a);

            if (Head != null)
            {
                Element p = Head;
                int c = 1;
                while (p.Next != null && c != i)
                {
                    p = p.Next;
                    c++;
                }
                if (c == i)
                {
                    if (p.Next != null)
                    {
                        NewNode.Next = p.Next;
                        NewNode.Prev = p;
                        p.Next.Prev = NewNode;
                        p.Next = NewNode;
                    }
                    else
                        this.AddLast(a);
                }
                else
                    throw new Exception("Элемент не найден");
            }

        }
        public void AddBefore(int i, T a)
        {
            if (Head != null)
            {
                if (i == 1)
                    this.AddFirst(a);
                else
                    this.AddAfter(i - 1, a);
            }
        }

        public T DelLast()
        {
            if (Last != null)
            {
                T a = Last.Data;
                if (Last.Prev != null)
                {
                    Last.Prev.Next = null;
                    Last = Last.Prev;
                }
                else
                {
                    Head = null;
                    Last = null;
                }
                return a;
            }
            else
                return default(T);
        }
        public T DelFirst()
        {
            if (Head != null)
            {
                T a = Head.Data;

                if (Head.Next != null)
                {
                    Head.Next.Prev = null;
                    Head = Head.Next;
                }
                else
                {
                    Last = null;
                    Head = null;
                }
                return a;
            }
            else
                return default(T);
        }

        public T Del(int i)
        {
            if (i != 1)
            {
                Element p = Head;
                Element q = p;
                int count = 1;
                while ((p.Next != null) && (count != i))
                {
                    q = p;
                    p = p.Next;
                    count++;
                }

                if (count == i)
                {
                    T a = p.Data;
                    if (p.Next != null)
                    {

                        q.Next = p.Next;
                        p.Next.Prev = q;
                        p.Next = null;
                        p.Prev = null;
                    }
                    else
                        this.DelLast();
                    return a;
                }
                else
                    throw new Exception("Элемент не найден");
            }
            else
                return this.DelFirst();
        }

        public T DelAfter(int i)
        {
            return Del(i + 1);
        }
        public T DelBefore(int i)
        {
            return Del(i - 1);
        }
        public T SearchByNumber(int i)
        {
            if (Head != null)
            {
                Element p = Last;
                int c = 1;
                while (p.Prev != null && Count - c != i - 1)
                {
                    p = p.Prev;
                    c++;
                }
                if (Count - c == i - 1)
                {
                    T a = p.Data;
                    return a;
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            } else
            {
                return default(T);
            }
        }

        public bool SearchByValue(T a)
        {
            if (Head != null)
            {
                Element p = Last;
                while (p.Prev != null)
                {
                    if (p.Data.ToString() == a.ToString())
                    {
                        return true;
                    }
                    p = p.Prev;
                }
                return false;
            }
            else
            {
                return false;
            }
        }
        public int Count
        {
            get
            {
                if (Head == null)
                {
                    return 0;
                }
                else
                {
                    int c = 1;
                    Element p = Head;

                    while (p.Next != null)
                    {
                        c += 1;
                        p = p.Next;
                    }
                    return c;

                }
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            var tmp = Head;
            while (tmp != null)
            {
                yield return tmp.Data;
                tmp = tmp.Next;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            string s = "";
            if (Head != null)
            {
                Element tmp = Head;
                while (tmp != null)
                {
                    s += tmp.Data + " ";
                    tmp = tmp.Next;
                }
            }
            return s;
        }
    }
}
