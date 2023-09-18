using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    public class ArrayCollection : Collection 
    {
        private int cap, SIZE; //Default Constructor
        private object[] data; //Default Constructor
        public ArrayCollection(int cap) //กำหนด Constructor หลังจาก Default Constructor
        {
            data = new object[cap];
            this.cap = cap;
        }
        private void ensureCapacity()
        {
            if (SIZE + 1 > data.Length)
            {
                object[] tempdata = new object[2 * SIZE];
                for (int i = 0; i < SIZE; i++)
                    tempdata[i] = data[i];
                data = tempdata;
            }
        }
        public void Add(object e)
        {
            ensureCapacity();
            data[SIZE++] = e;
        }
        private int indexOf(object e)
        {
            for (int i = 0; i < SIZE; i++)
                if (data[i].Equals(e))
                    return i;
            return -1;
        }
        public bool Contains(object e)
        {
            return indexOf(e) != -1;
        }

        public bool isEmpty()
        {
            return SIZE == 0;
        }

        public void remove(object e)
        {
            int i = indexOf(e);
            if (i != -1)
            {
                data[i] = data[--SIZE];
                data[SIZE] = null;
            }

        }

        public int size()
        {
            return SIZE;
        }

    }
}