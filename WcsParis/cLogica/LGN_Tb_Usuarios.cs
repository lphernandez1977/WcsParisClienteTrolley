using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace WcsParis
{    
    public class LGN_Tb_Usuarios
    {
        ACD_Tb_Usuarios _ACD_Tb_Usuarios = new ACD_Tb_Usuarios();

        public string Inserta_Tb_Usuarios(cTb_Usuarios oTb_Usuarios) 
        {
            string res = string.Empty;

            res = _ACD_Tb_Usuarios.Inserta_Usuarios(oTb_Usuarios);

            return res;
        }

        public string Editar_Tb_Usuarios(cTb_Usuarios oTb_Usuarios)
        {
            string res = string.Empty;

            res = _ACD_Tb_Usuarios.Editar_Tb_Usuarios(oTb_Usuarios);

            return res;
        }

        public DataSet Listado_Usuarios()
        {
            DataSet dsdatos = new DataSet();

            dsdatos = _ACD_Tb_Usuarios.Listado_Usuarios();

            return dsdatos;
        }

        public cTb_Usuarios Selecciona_Usuario(cTb_Usuarios oUser) 
        {
            cTb_Usuarios _oUsuario = new cTb_Usuarios();
            _oUsuario = _ACD_Tb_Usuarios.Selecciona_Usuario(oUser);
            return _oUsuario;
        }

        public string Actualiza_Passwword(cTb_Usuarios oUser)
        {
            string res = string.Empty;
            res = _ACD_Tb_Usuarios.Actualiza_Passwword(oUser);
            return res;
        }
    }
}
