using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace forhuff
{
    public class BinaryMinHeap
    {
        private HuffmanTree[] data;
        private int SIZE;
        private int cap;

        public BinaryMinHeap(int cap)
        {
            data = new HuffmanTree[cap];
            this.cap = cap;
        }

        public bool isEmpty() { return SIZE == 0; }
        public int size() { return SIZE; }
        public HuffmanTree peek()
        {
            if (isEmpty())
                throw new InvalidOperationException();
            return data[0];
        }

        public void Enqueue(HuffmanTree e)
        {
            EnsureCapacity();
            data[SIZE] = e;
            ReorderUp(SIZE++);
        }

        public HuffmanTree Dequeue()
        {
            HuffmanTree min = peek();
            data[0] = data[--SIZE];
            data[SIZE] = null;
            if (SIZE > 1) ReorderDown(0);
            return min;
        }

        private void ReorderDown(int k)
        {
            int c;
            while ((c = 2 * k + 1) < SIZE)
            {
                if (c + 1 < SIZE && IsGreaterThan(c + 1, c))
                    c++;
                if (!IsGreaterThan(c, k)) break;
                Swap(k, c);
                k = c;
            }
        }

        private void ReorderUp(int k)
        {
            while (k > 0)
            {
                int p = (k - 1) / 2;
                if (!IsGreaterThan(k, p))
                    break;
                Swap(k, p);
                k = p;
            }
        }

        private void Swap(int i, int j)
        {
            HuffmanTree temp = data[i];
            data[i] = data[j];
            data[j] = temp;
        }

        private bool IsGreaterThan(int i, int j)
        {
            return data[i].CompareTo(data[j]) < 0;
        }

        private void EnsureCapacity()
        {
            HuffmanTree[] tempdata;
            if (SIZE + 1 > data.Length)
                tempdata = new HuffmanTree[2 * data.Length + 1];
            else if (data.Length > cap && data.Length > 2 * SIZE)
                tempdata = new HuffmanTree[data.Length / 2 + 1];
            else return;
            for (int i = 0; i < SIZE; i++)
                tempdata[i] = data[i];
            data = tempdata;
        }
    }

}
