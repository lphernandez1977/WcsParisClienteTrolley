using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WcsParis
{
    public class cENT_Lista
    {
        public string Name { get; set; }
        public int Value { get; set; }

        public cENT_Lista(string name, int value)
        {
            Name = name;
            Value = value;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
