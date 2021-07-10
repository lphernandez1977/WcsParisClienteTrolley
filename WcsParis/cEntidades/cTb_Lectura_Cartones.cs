using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcsParis
{
    public class cTb_Lectura_Cartones
    {
        public int RecId { get; set; }
        public string CartonLPN { get; set; }
        public DateTime CreationTime { get; set; }
        public int Lane { get; set; }
        public string Store { get; set; }
        public string LabelCondition { get; set; }
        public string Result { get; set; }
        public DateTime ResultTime { get; set; }
        public bool StatusUpdFlag { get; set; }
        public string DtdSalida { get; set; }
    }
}
