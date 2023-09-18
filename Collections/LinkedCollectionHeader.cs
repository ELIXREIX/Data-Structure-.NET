using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    public class LinkedCollectionHeader : Collection
    {
        private class LinkedNode
        {
            public object e;
            public LinkedNode next;
            public LinkedNode(object e, LinkedNode next)
            {
                this.e = e;
                this.next = next;

            }
        }
        private LinkedNode first = new LinkedNode(null, null);
        private int SIZE;
        public void Add(object e)
        {
            first.next = new LinkedNode(e, first.next);
            SIZE++;
        }

        public bool Contains(object e)
        {
            LinkedNode node = first.next;
            while (node != null)
            {
                if (node.e.Equals(e)) return true;
                node = node.next;
            }
            return false;

        }

        public bool isEmpty()
        {
            return SIZE == 0;
        }

        public void remove(object e)
        {
            LinkedNode node = first;
            while (node.next != null)
            {
                if (node.next.e.Equals(e))
                {
                    node.next = node.next.next;
                    SIZE--; return;
                }
                node = node.next;
            }
        }

        public int size()
        {
            return SIZE;
        }
    }
}
