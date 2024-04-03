using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SinglyLinkedListClass
{
    class SinglyLinkedList<T> : IEnumerable<T>
    {
        private class Element
        {
            public T Data { set; get; }
            
            public Element Next { set; get; }

            public Element()
            {

            }
            public Element (T a)
            {
                Data = a;
                Next = null;
            }
        }
        Element Head = null;

        public void AddFirst(T a)
        {
            Element NewNode = new Element(a);
            NewNode.Next = Head;
            Head = NewNode;
        }

        public void AddLast(T a)
        {
            Element NewNode = new Element(a);
            if (Head != null)
            {
                Element p = Head;
                while (p.Next != null)
                {
                    p = p.Next;
                }
                p.Next = NewNode;
            }
            else
            {
                Head = NewNode;
            }
        }

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
                    NewNode.Next = p.Next;
                    p.Next = NewNode;
                } else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        public void AddBefore(int i, T a)
        {
            if (Head != null)
            {
                if (i == 1)
                {
                    this.AddFirst(a);
                }
                else
                {
                    this.AddAfter(i - 1, a);
                }
            }
        }

        public T DelFirst()
        {
            if (Head != null)
            {
                T a = Head.Data;
                Head = Head.Next;
                return a;
            } else
            {
                return default(T);
            }
        }

        public T DelLast()
        {
            if (Head != null)
            {
                if (Head.Next != null)
                {
                    Element p = Head;
                    while (p.Next.Next != null)
                    {
                        p = p.Next;
                    }
                    T a = p.Next.Data;
                    p.Next = null;
                    return a;
                }
                else
                {
                    T a = Head.Data;
                    Head = null;
                    return a;
                }
                
            } else
            {
                return default(T);
            }
        }

        public T Del(int i)
        {
            if (Head != null)
            {
                Element p = Head;
                Element q = p;
                int c = 1;
                if (i == 1)
                {
                    DelFirst();
                }
                while ((p.Next != null) && (c != i))
                {
                    q = p;
                    p = p.Next;
                    c++;
                }
                if (c == i)
                {
                    T a = p.Data;
                    q.Next = p.Next;
                    return a;
                } else
                {
                    throw new Exception("Элемент не найден");
                }
            } else
            {
                return default(T);
            }
        }
        public T DelAfter(int i)
        {
            return Del(i + 1);
        }

        public T DelBefore(int i)
        {
            return Del(i - 1);
        }

        public bool SearchByValue(T a)
        {
            if (Head != null)
            {
                Element p = Head;
                while (p != null)
                {
                    if (p.Data.ToString() == a.ToString())
                    {
                        return true;
                    }
                    p = p.Next;
                } 
                return false;
            } else
            {
                return false;
            }
        }
        public T SearchByNumber(int i)
        {
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
                    T a = p.Data;
                    return a;
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
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