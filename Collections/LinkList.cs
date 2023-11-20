using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Collections
{
    public class LinkList<T> : List

    {
        private LinkedNode first = new LinkedNode(default(T), null, null);
        private int SIZE;
        public LinkList()
        {
            first.back = first.next = first;
        }
        private class LinkedNode
        {
            public T e;
            public LinkedNode next;
            public LinkedNode back;

            public LinkedNode(T e, LinkedNode back, LinkedNode next)
            {
                this.e = e;
                this.back = back;
                this.next = next;
            }
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= SIZE)
                {
                    throw new IndexOutOfRangeException("Index is out of range");
                }

                return nodeAt(index).e;
            }
            set
            {
                if (index < 0 || index >= SIZE)
                {
                    throw new IndexOutOfRangeException("Index is out of range");
                }

                nodeAt(index).e = value;
            }
        }

        private void addBefore(LinkedNode node, T e)
        {
            LinkedNode newNode = new LinkedNode(e, node.back, node);
            node.back.next = newNode;
            node.back = newNode;
            SIZE++;
        }

        public void add(int index, T e)
        {
            addBefore(nodeAt(index), e);
        }

        public void add(T e)
        {
            addBefore(first, e);
        }
        private void removeNode(LinkedNode node)
        {
            LinkedNode before = node.back;
            LinkedNode after = node.next;
            before.next = after;
            after.back = before;
            SIZE--;
        }
        private LinkedNode nodeAt(int index)
        {
            LinkedNode node = first;
            for (int i = -1; i < index; i++)
                node = node.next;
            return node;
        }

        public bool Contains(object e)
        {
            return indexOf(e) > -1;
        }

        public object get(int index)
        {
            return nodeAt(index).e;
        }

        public int indexOf(object e)
        {
            LinkedNode node = first.next;
            for (int i = 0; i < SIZE; i++)
            {
                if (node.e.Equals(e))
                    return i;
                node = node.next;
            }
            return -1;
        }

        public bool isEmpty()
        {
            return SIZE == 0;
        }

        public void remove(int index)
        {
            removeNode(nodeAt(index));
        }

        public void remove(object e)
        {
            LinkedNode node = first.next;
            while (node != first)
            {
                if (node.e.Equals(e))
                {
                    removeNode(node);
                    return;
                }
                node = node.next;
            }   
        }

        public void set(int index, T e)
        {
            nodeAt(index).e = e;
        }

        public int size()
        {
            return SIZE;
        }

        public void add(int index, object e)
        {
            throw new NotImplementedException();
        }

        public void add(object e)
        {
            throw new NotImplementedException();
        }

        public void set(int index, object e)
        {
            throw new NotImplementedException();
        }
    }
}
