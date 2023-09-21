using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    public class LinkedCollection : Collection
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
        private LinkedNode first;
        private int SIZE;
        public LinkedCollection() {
        
        
        }
        public void Add(object e)
        {
            first = new LinkedNode(e, first);
            SIZE++;
        }

        public bool Contains(object e)
        {
            LinkedNode node = first;
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
            throw new NotImplementedException();
        }

        public int size()
        {
           return SIZE;
        }
    }
}
