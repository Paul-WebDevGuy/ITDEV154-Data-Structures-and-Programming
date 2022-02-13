using System;
using System.Collections.Generic;
using System.Text;

namespace assignment3_ITDEV154
{
    class node
    {
        //members
        public int data;
        public node next;

        //Constructor
        public node(int i)
        {
            data = i;
            next = null;
        }
    }
}
