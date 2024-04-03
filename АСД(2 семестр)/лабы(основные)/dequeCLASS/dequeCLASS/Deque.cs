using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace dequeCLASS
{
    class Deque<T> : IEnumerable<T>
    {
        private class Element
        {
            public T Data { set; get; }
            public Element Next { set; get; }
            public Element() { }
            public Element(T a)
            {
                Data = a;
                Next = null;
            }
        }
        Element Head = null;
        /// <summary>
        /// Добавляет элемент в начало дека
        /// </summary>
        /// <param name="a"></param>
        public void Push(T a)
        {
            Element tmp = new Element(a);
            if (Head != null)
            {
                tmp.Next = Head;
                Head = tmp;

            }
            else
            {
                Head = tmp;
            }

        }
        /// <summary>
        /// Удаляет элемент дека с начала
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            if (Head != null)
            {
                T a = Head.Data;
                Head = Head.Next;
                return a;
            }
            else
            {
                return default(T);
            }
        }

        /// <summary>
        /// Добавляет элемент в конец дека
        /// </summary>
        /// <param name="a"></param>
        public void PushTail(T a)
        {

            Element tmp = new Element(a);

            if (Head != null)
            {
                Element p = Head;
                while (p.Next != null)
                {
                    p = p.Next;
                }
                p.Next = tmp;

            }
            else
            {
                Head = tmp;
            }
        }
        /// <summary>
        /// Удаляет последний элемент дека
        /// </summary>
        /// <returns></returns>
        public T PopTail()
        {
            if (Head != null)
            {
                Element p = Head.Next;
                Element m = Head;
                while (p.Next != null)
                {
                    m = m.Next;
                    p = p.Next;
                }
                T a = p.Data;
                m.Next = null;
                return a;
            }
            else
            {
                return default(T);
            }
        }

        /// <summary>
        /// Возвращает первый элемент дека
        /// </summary>
        /// <returns></returns>
        public T First()
        {
            if (Head != null)
            {
                return Head.Data;
            }
            else
            {
                return default(T);
            }
        }

        /// <summary>
        /// Вовзращает последний элемент дека
        /// </summary>
        /// <returns></returns>
        public T Last()
        {
            if (Head != null)
            {
                Element p = Head;
                while (p.Next != null)
                {
                    p = p.Next;
                }
                return p.Data;
            }
            else
            {
                return default(T);
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
