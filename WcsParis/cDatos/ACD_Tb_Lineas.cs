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
    public class ACD_Tb_Lineas
    {
        public DataSet Listado_Salidas()
        {
            DataSet ds = new DataSet();
            try
            {
                //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnString"].ToString()))
                {
                    //asignar los valores proporcionados a estos parámetros sobre la base de orden de los parámetros
                    using (SqlCommand cmd = new SqlCommand("sp_selec_Lineas", con))
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

        public string Inserta_Tb_Salidas(cTb_Lineas oTb_Lineas)
        {
            int res = 0;
            try
            {
                SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnString"].ToString());
                SqlCommand cmd = new SqlCommand("sp_Insert_Lineas", cnx);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@pNumLinea", System.Data.SqlDbType.Int).Value = oTb_Lineas.IdLinea;
                cmd.Parameters.Add("@pEstLinea", System.Data.SqlDbType.Int).Value = oTb_Lineas.IdEstado;
                cmd.Parameters.Add("@pNomEstado", System.Data.SqlDbType.VarChar,20).Value = oTb_Lineas.NomEstado;
  
                //parametros de salida
                cmd.Parameters.Add("@Pgi_Salida", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@pMensaje_Error", SqlDbType.VarChar, 255).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@pMensaje_Ok", SqlDbType.VarChar, 255).Direction = ParameterDirection.Output;
                cnx.Open();
                res = cmd.ExecuteNonQuery();

                int Salida = Convert.ToInt32(cmd.Parameters["@Pgi_Salida"].Value);
                string MensajeOK = cmd.Parameters["@pMensaje_Ok"].Value.ToString();
                string MensajeErr = cmd.Parameters["@pMensaje_Error"].Value.ToString();

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

        public string Editar_Tb_Salidas(cTb_Lineas oTb_Lineas)
        {
            int res = 0;
            try
            {
                SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnString"].ToString());
                SqlCommand cmd = new SqlCommand("sp_Modifica_Lineas", cnx);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@pNumLinea", System.Data.SqlDbType.Int).Value = oTb_Lineas.IdLinea;
                cmd.Parameters.Add("@pEstLinea", System.Data.SqlDbType.Int).Value = oTb_Lineas.IdEstado;
                cmd.Parameters.Add("@pNomEstado", System.Data.SqlDbType.VarChar, 20).Value = oTb_Lineas.NomEstado;

                //parametros de salida
                cmd.Parameters.Add("@Pgi_Salida", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@pMensaje_Error", SqlDbType.VarChar, 255).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@pMensaje_Ok", SqlDbType.VarChar, 255).Direction = ParameterDirection.Output;
                cnx.Open();
                res = cmd.ExecuteNonQuery();

                int Salida = Convert.ToInt32(cmd.Parameters["@Pgi_Salida"].Value);
                string MensajeOK = cmd.Parameters["@pMensaje_Ok"].Value.ToString();
                string MensajeErr = cmd.Parameters["@pMensaje_Error"].Value.ToString();

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

        public DataSet Listado_SalidasActivas()
        {
            DataSet ds = new DataSet();
            try
            {
                //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnString"].ToString()))
                {
                    //asignar los valores proporcionados a estos parámetros sobre la base de orden de los parámetros
                    using (SqlCommand cmd = new SqlCommand("sp_selec_LineasActivas", con))
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

        public string ConfNuevasSalidas(cTb_Lineas oLineas, ENT_Tb_Tiendas oTiendas)
        {
            int res = 0;
            try
            {
                SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnString"].ToString());
                SqlCommand cmd = new SqlCommand("sp_ConfSalidasTroll", cnx);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@pLinea", System.Data.SqlDbType.Int).Value = oLineas.IdLinea;
                cmd.Parameters.Add("@pTDestino", System.Data.SqlDbType.VarChar, 3).Value = oTiendas.Alias_Tienda;

                //parametros de salida
                cmd.Parameters.Add("@Pgi_Salida", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@pMnesaje", SqlDbType.VarChar, 255).Direction = ParameterDirection.Output;
                cnx.Open();
                res = cmd.ExecuteNonQuery();

                int Salida = Convert.ToInt32(cmd.Parameters["@Pgi_Salida"].Value);
                string Mensaje = cmd.Parameters["@pMnesaje"].Value.ToString();
 
                cnx.Close();
                cnx.Dispose();

                if (Salida == 1)
                {
                    return "1";
                }
                else
                {
                    return Mensaje;
                }

            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }

        }

        public string Eliminar_Tienda_Salida(cTb_Lineas oLineas, ENT_Tb_Tiendas oTiendas)
        {
            int res = 0;
            try
            {
                SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnString"].ToString());
                SqlCommand cmd = new SqlCommand("sp_Elimina_LineasTiendas", cnx);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@pNumLinea", System.Data.SqlDbType.Int).Value = oLineas.IdLinea;
                cmd.Parameters.Add("@pAliasTien", System.Data.SqlDbType.VarChar,3).Value = oTiendas.Alias_Tienda;

                //parametros de salida
                cmd.Parameters.Add("@Pgi_Salida", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@pMensaje", SqlDbType.VarChar, 255).Direction = ParameterDirection.Output;

                cnx.Open();
                res = cmd.ExecuteNonQuery();

                int Salida = Convert.ToInt32(cmd.Parameters["@Pgi_Salida"].Value);
                string Mensaje = cmd.Parameters["@pMensaje"].Value.ToString();

                cnx.Close();
                cnx.Dispose();

                if (Salida == 1)
                {
                    return "1";
                }
                else
                {
                    return Mensaje;
                }

            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }

        }
    }
}
