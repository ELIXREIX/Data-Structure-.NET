using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackTest
{
    public class LinkedStack : Stack
    {
        private int SIZE;
        private LinkedNode first;
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
        public bool isEmpty()
        {
            return SIZE == 0;
        }

        public object peek()
        {
            if (isEmpty())
                throw new System.MissingMemberException();
            return first.e;
        }

        public object pop()
        {
            object e = peek();
            first = first.next;
            SIZE--;
            return e;
        }

        public void push(object e)
        {
            first = new LinkedNode(e, first);
            SIZE++;
        }

        public int size()
        {
            return SIZE;
        }
    }
}
