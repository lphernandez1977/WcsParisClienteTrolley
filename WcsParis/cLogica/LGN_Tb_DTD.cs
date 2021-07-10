using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace WcsParis
{
    public class LGN_Tb_DTD
    {
        ACD_Tb_Dtd _ACD_Tb_Dtd = new ACD_Tb_Dtd();

        public DataSet Listado_DTD()
        {
            DataSet dsdatos = new DataSet();

            dsdatos = _ACD_Tb_Dtd.Listado_Dtd();

            return dsdatos;
        }

        public string Inserta_Tb_DTD(cENT_Dtd _cENT_Dtd)
        {
            string res = string.Empty;

            res = _ACD_Tb_Dtd.Inserta_Tb_DTD(_cENT_Dtd);

            return res;
        }

        public string Actualizar_Tb_DTD(cENT_Dtd _cENT_Dtd)
        {
            string res = string.Empty;

            res = _ACD_Tb_Dtd.Modificar_Tb_DTD(_cENT_Dtd);

            return res;
        }
    }
}
