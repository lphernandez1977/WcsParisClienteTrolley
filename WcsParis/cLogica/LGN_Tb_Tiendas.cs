using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace WcsParis
{
    public class LGN_Tb_Tiendas
    {
        ACD_Tb_Tiendas _ACD_Tb_Tiendas = new ACD_Tb_Tiendas();

        public string Inserta_Tiendas(ENT_Tb_Tiendas oTiendas) 
        {
            string res = string.Empty;

            res = _ACD_Tb_Tiendas.Inserta_Tiendas(oTiendas);

            return res;
        
        }
       
        public DataSet Listado_Tiendas()
        {
            DataSet dsdatos = new DataSet();

            dsdatos = _ACD_Tb_Tiendas.Listado_Tiendas();

            return dsdatos;
        }

        public DataSet Listado_Tiendas_2()
        {
            DataSet dsdatos = new DataSet();

            dsdatos = _ACD_Tb_Tiendas.Listado_Tiendas_2();

            return dsdatos;
        }

        public DataSet Listado_LineasxTienda()
        {
            DataSet dsdatos = new DataSet();

            dsdatos = _ACD_Tb_Tiendas.Listado_LineasxTienda();

            return dsdatos;
        }

        public string Editar_Tiendas(ENT_Tb_Tiendas oTiendas)
        {
            string res = string.Empty;

            res = _ACD_Tb_Tiendas.Editar_Tiendas(oTiendas);

            return res;

        }
    }
}
