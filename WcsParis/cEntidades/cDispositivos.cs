using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcsParis
{
    public class cDispositivos
    {
        public string IpPLC { get; set; }
        public Int16 PortPLC { get; set; }
        public Int16 RackPLC { get; set; }
        public Int16 SlotPLC { get; set; }
        public int NumDb { get; set; }
        public string PtoCOM { get; set; }
    }
}
