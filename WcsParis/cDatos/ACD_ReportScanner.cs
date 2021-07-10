using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Agregadas
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WcsParis
{
    public class ACD_ReportScanner
    {
        public DataSet Listado_ReportScanner(string oFecha, string oFechaTer)
        {
            DataSet ds = new DataSet();
            try
            {
                //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnString"].ToString()))
                {
                    //asignar los valores proporcionados a estos parámetros sobre la base de orden de los parámetros
                    using (SqlCommand cmd = new SqlCommand("sp_selec_reporte_scanner", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add("@pFecha", System.Data.SqlDbType.VarChar, 10).Value = oFecha;
                        cmd.Parameters.Add("@pFechaTer", System.Data.SqlDbType.VarChar, 10).Value = oFechaTer;
                        //abrimos conexion
                        con.Open();
                        //Ejecutamos Procedimiento                        
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        //llenar el conjunto de datos utilizando los valores predeterminados para los nombres de DataTable, etc 
                        adapter.Fill(ds);
                        //Cierre conexion
                        con.Close();
                        //retorna los datos
                        return ds;
                    }
                }
            }
            catch (SqlException ex)
            {
                return null;
            }
        }
    }
}
