using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcsParis
{
    public class cTb_Nivel
    {
        public string Name { get; set; }
        public int Value { get; set; }

        public cTb_Nivel(string name, int value)
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
