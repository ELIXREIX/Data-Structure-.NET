using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    public class LinkedSet : LinkedCollectionHeader, Set
    {
        public new void Add(object e)
        {
            if (!base.Contains(e))
                base.Add(e);
        }
    }

}