using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    public interface Queuecs
    {
        bool isEmpty();
        int size();
        void enqueue(object e);
        object dequeue();
        object peek();
    }
}
