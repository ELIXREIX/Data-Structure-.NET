using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Collections
{
    public class LinkList : List

    {
        public LinkList()
        {
            first.back = first.next = first;
        }
        private LinkedNode first = new LinkedNode(null, null, null);
        private int SIZE;
        private class LinkedNode
        {
            public object e;
            public LinkedNode next;
            public LinkedNode back;
            public LinkedNode(object e, LinkedNode back, LinkedNode next)
            {
                this.e = e;
                this.back = back;
                this.next = next;
            }
        }
        private void addBefore(LinkedNode node, object e)
        {
            LinkedNode newNode = new LinkedNode(e, node.back, node);
            node.back.next = newNode;
            node.back = newNode;
            SIZE++;
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
        public void add(int index, object e)
        {
            addBefore(nodeAt(index), e);
        }

        public void add(object e)
        {
            addBefore(first, e);
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

        public void set(int index, object e)
        {
            nodeAt(index).e = e;
        }

        public int size()
        {
            return SIZE;
        }
    }
}
