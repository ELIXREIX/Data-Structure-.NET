using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Collections;
namespace Queue
{
    public class ArrayListPriotiyQueue : PriorityQueue
    {
        private List list;

        private int HighestPriorityIndex()
        {
            if(isEmpty())
                throw new System.MissingMemberException();
            int i = 0;
            for (int j = 1; j < list.size();j++)
            {
                IComparable c = (IComparable)list.get(j);
                if (c.CompareTo(list.get(i)) > 0)
                    i = j;
            }
            return i;
        }
        public ArrayListPriotiyQueue(int cap)
        {
            list = new Arraylist(cap);
        }

        public object dequeue()
        {
           int i = HighestPriorityIndex();
           object e = list.get(i);
           list.remove(i);
           return e;
        }

        public void enqueue(object e)
        {
            list.add(e);
        }

        public bool isEmpty()
        {
            return list.isEmpty();
        }

        public object peek()
        {
            return list.get(HighestPriorityIndex());
        }

        public int size()
        {
            return list.size();
        }
    }
}
