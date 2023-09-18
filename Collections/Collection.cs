using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    public interface Collection
    {
        void Add(object e);
        void remove (object e);
        bool Contains(object e);
        int size();
        bool isEmpty();


    }
}
