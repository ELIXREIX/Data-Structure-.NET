using Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    public class LinkListQueue : Queuecs
    {
        private List list;

        public LinkListQueue()
        {
            list = new LinkList();
        }

        public object dequeue()
        {
            object e = peek();
            list.remove(0);
            return e;
        }

        public void enqueue(object e)
        {
            list.add(e);
        }

        public bool isEmpty()
        {
            return list.size() == 0;
        }

        public object peek()
        {
            if (isEmpty())
                throw new System.MissingMemberException();
            return list.get(0);
        }

        public int size()
        {
            return list.size();
        }
    }
}
