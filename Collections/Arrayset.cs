﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    public class Arrayset : ArrayCollection, Set
    {
        public Arrayset(int cap) : base(cap) { }
        public new void add(object e)
        {
            if (!base.Contains(e))
                base.add(e);
        }
    }
}
