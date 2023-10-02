using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    public interface Collection
    {
        void add(object e);
        void remove (object e);
        bool Contains(object e);
        int size();
        bool isEmpty();
        object get(int i);
        void set(int index, object e);
        void remove(int index);
        void add(int index, object e);
    }
}
