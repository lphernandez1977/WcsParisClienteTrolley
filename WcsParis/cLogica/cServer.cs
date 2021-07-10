using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace WcsParis.cLogica
{   
    public class cServer
    {
        Datos_Server oDatos_Server = new Datos_Server();

        public string RecuperaFechaServidor() 
        {
            string resultado = string.Empty;
            resultado = oDatos_Server.RecuperaFechaServidor();
            return resultado;        
        }

    }
}
