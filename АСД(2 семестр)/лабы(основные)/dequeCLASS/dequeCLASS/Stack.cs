﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace dequeCLASS
{
    class Stack<T> : IEnumerable<T>
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
        public T Peek()
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
