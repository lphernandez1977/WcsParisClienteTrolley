using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WcsParis
{
    public class LGN_ReportScanner
    {
        ACD_ReportScanner _ACD_ReportScanner = new ACD_ReportScanner();

        public DataSet Listado_ReportScanner(string oFecha, string oFechaTer)
        {
            DataSet dsdatos = new DataSet();

            dsdatos = _ACD_ReportScanner.Listado_ReportScanner(oFecha, oFechaTer);

            return dsdatos;
        }
    }
}
