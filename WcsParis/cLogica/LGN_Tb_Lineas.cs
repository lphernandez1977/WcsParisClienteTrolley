using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace WcsParis
{
    public class LGN_Tb_Lineas
    {
        ACD_Tb_Lineas _ACD_Tb_Lineas = new ACD_Tb_Lineas();

        public DataSet Listado_Salidas()
        {
            DataSet dsdatos = new DataSet();

            dsdatos = _ACD_Tb_Lineas.Listado_Salidas();

            return dsdatos;
        }

        public string Inserta_Tb_Salidas(cTb_Lineas oTb_Salidas)
        {
            string res = string.Empty;

            res = _ACD_Tb_Lineas.Inserta_Tb_Salidas(oTb_Salidas);

            return res;
        }

        public string Editar_Tb_Salidas(cTb_Lineas oTb_Salidas)
        {
            string res = string.Empty;

            res = _ACD_Tb_Lineas.Editar_Tb_Salidas(oTb_Salidas);

            return res;
        }

        public DataSet Listado_SalidasActivas()
        {
            DataSet dsdatos = new DataSet();

            dsdatos = _ACD_Tb_Lineas.Listado_SalidasActivas();

            return dsdatos;
        }

        public string ConfNuevasSalidas(cTb_Lineas oLineas, ENT_Tb_Tiendas oTiendas) 
        {
            string res = string.Empty;

            res = _ACD_Tb_Lineas.ConfNuevasSalidas(oLineas, oTiendas);

            return res;
        
        }

        public string Eliminar_Tienda_Salida(cTb_Lineas oLineas, ENT_Tb_Tiendas oTiendas)
        {
            string res = string.Empty;

            res = _ACD_Tb_Lineas.Eliminar_Tienda_Salida(oLineas, oTiendas);

            return res;
        }
    }
}   
