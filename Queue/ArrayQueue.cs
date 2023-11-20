using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    public class ArrayQueue : Queuecs
    {
        private object[] data;
        private int firstindex;
        private int cap;
        private int SIZE;
        public ArrayQueue(int cap)
        {
            data = new object[cap];
            this.cap = cap;

        }
        private void ensureCapacity()
        {
            object[] tempdata;
            if (SIZE + 1 > data.Length)
                tempdata = new object[data.Length];
            else if (data.Length > cap && data.Length > 2 * SIZE)
                tempdata = new object[data.Length / 2 + 1];
            else return;
            for (int i = 0; i < SIZE; i++)
                tempdata[i] = data[i];
            firstindex = 0;
            data = tempdata;
            
        }
        public object dequeue()
        {
            object e = peek();
            data[firstindex++] = null;
            SIZE--;
            return e;
        }

        public void enqueue(object e)
        {
            ensureCapacity();
            data[firstindex + SIZE++] = e;
        }

        public bool isEmpty()
        {
            return SIZE == 0; 
        }

        public object peek()
        {
            if(isEmpty())
                throw new System.MissingMemberException();
            return data[firstindex];
        }

        public int size()
        {
            return SIZE;
        }
    }
}
