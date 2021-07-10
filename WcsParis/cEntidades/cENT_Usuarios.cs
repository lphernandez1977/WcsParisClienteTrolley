using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcsParis
{
    public class cENT_Usuarios
    {
        public int Codigo_Funcionario { get; set; }
        public int Cod_Sistema { get; set; }
        public int Cod_SubSistema { get; set; }
        public int Rut_Funcionario { get; set; }
        public string Password { get; set; }
        public string Comentarios { get; set; }
    }
}
