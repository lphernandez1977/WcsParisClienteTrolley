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
    public class ACD_Tb_Dtd
    {
        public DataSet Listado_Dtd()
        {
            DataSet ds = new DataSet();
            try
            {
                //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnString"].ToString()))
                {
                    //asignar los valores proporcionados a estos parámetros sobre la base de orden de los parámetros
                    using (SqlCommand cmd = new SqlCommand("sp_select_Listado_Dtd", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        //cmd.Parameters.Add("@pRut", System.Data.SqlDbType.Float).Value = rutsta;
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

        public string Inserta_Tb_DTD(cENT_Dtd _cENT_Dtd)
        {
            int res = 0;
            try
            {
                SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnString"].ToString());
                SqlCommand cmd = new SqlCommand("sp_Insert_DTD", cnx);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@In_IdLinea", System.Data.SqlDbType.Int).Value = _cENT_Dtd.IdLinea;
                cmd.Parameters.Add("@In_Destino", System.Data.SqlDbType.VarChar, 20).Value = _cENT_Dtd.Location;

                //parametros de salida
                cmd.Parameters.Add("@Pgi_Salida", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@out_Mensaje_Error", SqlDbType.VarChar, 255).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@out_Mensaje_Ok", SqlDbType.VarChar, 255).Direction = ParameterDirection.Output;

                cnx.Open();
                res = cmd.ExecuteNonQuery();

                int Salida = Convert.ToInt32(cmd.Parameters["@Pgi_Salida"].Value);
                string MensajeOK = cmd.Parameters["@out_Mensaje_Error"].Value.ToString();
                string MensajeErr = cmd.Parameters["@out_Mensaje_Ok"].Value.ToString();

                cnx.Close();
                cnx.Dispose();

                if (Salida == 1)
                {
                    return "1";
                }
                else
                {
                    return MensajeErr;
                }

            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }

        }

        public string Modificar_Tb_DTD(cENT_Dtd _cENT_Dtd)
        {
            int res = 0;
            try
            {
                SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnString"].ToString());
                SqlCommand cmd = new SqlCommand("sp_Modifica_DTD", cnx);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@In_IdLinea", System.Data.SqlDbType.Int).Value = _cENT_Dtd.IdLinea;
                cmd.Parameters.Add("@In_Destino", System.Data.SqlDbType.VarChar, 20).Value = _cENT_Dtd.Location;

                //parametros de salida
                cmd.Parameters.Add("@Pgi_Salida", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@out_Mensaje_Error", SqlDbType.VarChar, 255).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@out_Mensaje_Ok", SqlDbType.VarChar, 255).Direction = ParameterDirection.Output;

                cnx.Open();
                res = cmd.ExecuteNonQuery();

                int Salida = Convert.ToInt32(cmd.Parameters["@Pgi_Salida"].Value);
                string MensajeOK = cmd.Parameters["@out_Mensaje_Error"].Value.ToString();
                string MensajeErr = cmd.Parameters["@out_Mensaje_Ok"].Value.ToString();

                cnx.Close();
                cnx.Dispose();

                if (Salida == 1)
                {
                    return "1";
                }
                else
                {
                    return MensajeErr;
                }

            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }

        }
    }
}
