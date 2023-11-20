using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackTest
{
    public interface Stack
    {
        void push(object e);
        object pop();
        object peek();
        int size();
        bool isEmpty();
    }
}
