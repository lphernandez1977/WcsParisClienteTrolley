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
    public class ACD_Tb_Tiendas
    {
        public string Inserta_Tiendas(ENT_Tb_Tiendas oTiendas)
        {
            int res = 0;
            try
            {
                SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnString"].ToString());
                SqlCommand cmd = new SqlCommand("sp_Insert_Tiendas", cnx);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@pNumTienda", System.Data.SqlDbType.Int).Value = oTiendas.Num_Tienda;
                cmd.Parameters.Add("@pNomTienda", System.Data.SqlDbType.VarChar, 20).Value = oTiendas.Nom_Tienda;
                cmd.Parameters.Add("@pNomCorto", System.Data.SqlDbType.VarChar,4).Value = oTiendas.Alias_Tienda;
       
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
        public DataSet Listado_Tiendas_2()
        {
            DataSet ds = new DataSet();
            try
            {
                //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnString"].ToString()))
                {
                    //asignar los valores proporcionados a estos parámetros sobre la base de orden de los parámetros
                    using (SqlCommand cmd = new SqlCommand("sp_selec_Tiendas", con))
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

        public DataSet Listado_Tiendas()
        {
            DataSet ds = new DataSet();
            try
            {
                //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnString"].ToString()))
                {
                    //asignar los valores proporcionados a estos parámetros sobre la base de orden de los parámetros
                    using (SqlCommand cmd = new SqlCommand("sp_selec_Tiendas_cadena", con))
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

        public string Editar_Tiendas(ENT_Tb_Tiendas oTiendas)
        {
            int res = 0;
            try
            {
                SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnString"].ToString());
                SqlCommand cmd = new SqlCommand("sp_Modifica_Tiendas", cnx);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@pNumTienda", System.Data.SqlDbType.Int).Value = oTiendas.Num_Tienda;
                cmd.Parameters.Add("@pNomTienda", System.Data.SqlDbType.VarChar, 20).Value = oTiendas.Nom_Tienda.ToUpper();
                cmd.Parameters.Add("@pNomCorto", System.Data.SqlDbType.VarChar, 4).Value = oTiendas.Alias_Tienda.ToUpper();

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

        public DataSet Listado_LineasxTienda()
        {
            DataSet ds = new DataSet();
            try
            {
                //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnString"].ToString()))
                {
                    //asignar los valores proporcionados a estos parámetros sobre la base de orden de los parámetros
                    using (SqlCommand cmd = new SqlCommand("sp_select_ListadoLineasxTiendas", con))
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

    }
}
