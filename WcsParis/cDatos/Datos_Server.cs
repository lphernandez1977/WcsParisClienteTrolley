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
    public class Datos_Server
    {
        public string RecuperaFechaServidor()
        {
            string Fecha = "";
            try
            {
                //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnString"].ToString()))
                {
                    //asignar los valores proporcionados a estos parámetros sobre la base de orden de los parámetros
                    using (SqlCommand cmd = new SqlCommand("sp_selec_FechaHora", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        //abrimos conexion
                        con.Open();

                        SqlDataReader dataReader = cmd.ExecuteReader();
                        //Preguntamos si el DataReader fue devuelto con datos
                        while (dataReader.Read())
                        {
                            Fecha = Convert.ToString(dataReader["FechaHora"]);
                        }
                    }
                }
                return Fecha;
            }
            catch (SqlException ex)
            {
                return null;
            }

        }
    }
}
