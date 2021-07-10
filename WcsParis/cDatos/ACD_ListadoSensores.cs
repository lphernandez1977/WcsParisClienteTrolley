using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WcsParis
{   

    public class ACD_ListadoSensores
    {        
        public DataSet Listado_Sensores(string pUbic, string pTipo)
        {
            DataSet ds = new DataSet();
            try
            {
                //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnString"].ToString()))
                {
                    //asignar los valores proporcionados a estos parámetros sobre la base de orden de los parámetros
                    using (SqlCommand cmd = new SqlCommand("sp_select_tag", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        //El primero de los cambios significativos con respecto al ejemplo descargado es que aqui...
                        //ya no leeremos controles sino usaremos las propiedades del Objeto EProducto de nuestra capa
                        //de entidades...
                        cmd.Parameters.Add("@pUbicacion", SqlDbType.VarChar, 20).Value = pUbic.Trim();
                        cmd.Parameters.Add("@pTipo", SqlDbType.VarChar, 20).Value = pTipo.Trim();
                        //cmd.Parameters.Add("@FechaTer", SqlDbType.NVarChar).Value = FechaFin;


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
                ds = null;
                //devolver el conjunto de datos
                return ds;
            }
  
        }
    }
}
