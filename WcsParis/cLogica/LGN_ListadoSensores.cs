using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace WcsParis
{
    public class LGN_ListadoSensores
    {
        ACD_ListadoSensores _ACD_ListadoSensores = new ACD_ListadoSensores();

        public DataSet Listado_Sensores(string pUbic, string pTipo)
        {
            try {
                DataSet dsSensores = new DataSet();
                dsSensores = _ACD_ListadoSensores.Listado_Sensores(pUbic, pTipo);
                return dsSensores;
            }
            catch (Exception ex) 
            {
                return null;            
            }

        }
    }
}
