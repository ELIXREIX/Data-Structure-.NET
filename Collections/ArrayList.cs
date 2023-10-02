using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    public class Arraylist : List

    {
        private int cap, SIZE; //Default Constructor
        private object[] data; //Default Constructor
        public Arraylist(int cap) {
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

        public void add(int index, object e)
        {
            ensureCapacity();
            for (int i = SIZE; i > index; i--)
                data[i] = data[i - 1];
            data[index] = e;
            SIZE++;
        }

        public void remove(int index)
        {
            if (index >= SIZE) return;
            for (int i = index + 1; i < SIZE; i++)
                data[i-1] = data[i];
            data[--SIZE] = null;
        }

        public void remove(object e)
        {
            int i = indexOf(e);
            if (i >-1)
                remove(i);
        }

        public int size()
        {
            return SIZE;
        }
        public bool Contains(object e)
        {
            return indexOf(e) != -1;
        }
        public int indexOf(object e)
        {
            for (int i = 0; i < SIZE; i++)
                if (data[i].Equals(e))
                    return i;
            return -1;
        }
        public bool isEmpty()
        {
            return SIZE == 0;
        }

        int List.indexOf(object e)
        {
            throw new NotImplementedException();
        }

        public void add(object e)
        {
            ensureCapacity();
            data[SIZE++] = e;
        }

        public object get(int index)
        {
            return data[index];
        }

        public void set(int index, object e)
        {
            data[index] = e;
        }
    }
}
