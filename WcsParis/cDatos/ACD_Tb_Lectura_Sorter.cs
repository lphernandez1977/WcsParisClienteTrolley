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
    public class ACD_Tb_Lectura_Sorter
    {
        public cTb_Lectura_Cartones Inserta_Lectura_Cartones(cTb_Lectura_Cartones oTb_Lectura_Cartones)
        {
            cTb_Lectura_Cartones oLecturaCartones = new cTb_Lectura_Cartones();
            int res = 0;
            try
            {
                SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnString"].ToString());
                SqlCommand cmd = new SqlCommand("sp_Insert_Lectura_Cartones", cnx);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@pCartonLPN", System.Data.SqlDbType.VarChar, 20).Value = oTb_Lectura_Cartones.CartonLPN;
                cmd.Parameters.Add("@pStatusUpdFlag", System.Data.SqlDbType.Bit).Value = oTb_Lectura_Cartones.StatusUpdFlag;
                            
                //parametros de salida
                cmd.Parameters.Add("@pDestino", SqlDbType.VarChar,3).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@pLinea", SqlDbType.VarChar,3).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@pDtd", SqlDbType.VarChar, 7).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;

                cnx.Open();
                res = cmd.ExecuteNonQuery();

                oLecturaCartones.Store = cmd.Parameters["@pDestino"].Value.ToString();
                oLecturaCartones.Lane = Convert.ToInt32(cmd.Parameters["@pLinea"].Value);
                oLecturaCartones.DtdSalida = cmd.Parameters["@pDtd"].Value.ToString();
                oLecturaCartones.Result = cmd.Parameters["@Resultado"].Value.ToString();

                cnx.Close();
                cnx.Dispose();

                return oLecturaCartones;

            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public string Editar_Tb_Usuarios(cTb_Usuarios oTb_Usuarios)
        {
            int res = 0;
            try
            {
                SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnString"].ToString());
                SqlCommand cmd = new SqlCommand("sp_Modifica_Usuarios", cnx);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@pNom_Usuario", System.Data.SqlDbType.VarChar, 20).Value = oTb_Usuarios.Nom_Usuario;
                cmd.Parameters.Add("@pPass", System.Data.SqlDbType.VarChar, 20).Value = oTb_Usuarios.Contrasenia;
                cmd.Parameters.Add("@pNivel", System.Data.SqlDbType.Int).Value = oTb_Usuarios.Nivel;
                cmd.Parameters.Add("@pEstado", System.Data.SqlDbType.Bit).Value = oTb_Usuarios.Estado_Usuario;

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

        public string Modificar_CartonLPN(int _Linea, string _CartonLPN)
        {
            int res = 0;
            try
            {
                SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnString"].ToString());
                SqlCommand cmd = new SqlCommand("sp_Modifica_CartonLPN", cnx);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@pCarton", System.Data.SqlDbType.VarChar, 13).Value = _CartonLPN;
                cmd.Parameters.Add("@pLinea", System.Data.SqlDbType.Int).Value = _Linea;

                //parametros de salida
                cmd.Parameters.Add("@pSalida", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@pMensaje", SqlDbType.VarChar, 255).Direction = ParameterDirection.Output;
                //cmd.Parameters.Add("@pMensaje_Ok", SqlDbType.VarChar, 255).Direction = ParameterDirection.Output;
                cnx.Open();
                res = cmd.ExecuteNonQuery();

                int Salida = Convert.ToInt32(cmd.Parameters["@pSalida"].Value);
                string MensajeOK = cmd.Parameters["@pMensaje"].Value.ToString();
                //string MensajeErr = cmd.Parameters["@pMensaje_Error"].Value.ToString();

                cnx.Close();
                cnx.Dispose();

                if (Salida == 1)
                {
                    return "1";
                }
                else
                {
                    return MensajeOK;
                }

            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        public string Modificar_CartonLPN_Recirc(string _CartonLPN)
        {
            int res = 0;
            try
            {
                SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnString"].ToString());
                SqlCommand cmd = new SqlCommand("sp_Modifica_CartonLPN_Recirc", cnx);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@pCarton", System.Data.SqlDbType.VarChar, 13).Value = _CartonLPN;
                //cmd.Parameters.Add("@pLinea", System.Data.SqlDbType.Int).Value = _Linea;

                //parametros de salida
                cmd.Parameters.Add("@pSalida", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@pMensaje", SqlDbType.VarChar, 255).Direction = ParameterDirection.Output;
                //cmd.Parameters.Add("@pMensaje_Ok", SqlDbType.VarChar, 255).Direction = ParameterDirection.Output;
                cnx.Open();
                res = cmd.ExecuteNonQuery();

                int Salida = Convert.ToInt32(cmd.Parameters["@pSalida"].Value);
                string MensajeOK = cmd.Parameters["@pMensaje"].Value.ToString();
                //string MensajeErr = cmd.Parameters["@pMensaje_Error"].Value.ToString();

                cnx.Close();
                cnx.Dispose();

                if (Salida == 1)
                {
                    return "1";
                }
                else
                {
                    return MensajeOK;
                }

            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        public string Modificar_CartonLPN_FullLine(int _Linea, string _CartonLPN)
        {
            int res = 0;
            try
            {
                SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnString"].ToString());
                SqlCommand cmd = new SqlCommand("sp_Modifica_CartonLPN_Full", cnx);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@pCarton", System.Data.SqlDbType.VarChar, 13).Value = _CartonLPN;
                cmd.Parameters.Add("@pLinea", System.Data.SqlDbType.Int).Value = _Linea;

                //parametros de salida
                cmd.Parameters.Add("@pSalida", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@pMensaje", SqlDbType.VarChar, 255).Direction = ParameterDirection.Output;
                //cmd.Parameters.Add("@pMensaje_Ok", SqlDbType.VarChar, 255).Direction = ParameterDirection.Output;
                cnx.Open();
                res = cmd.ExecuteNonQuery();

                int Salida = Convert.ToInt32(cmd.Parameters["@pSalida"].Value);
                string MensajeOK = cmd.Parameters["@pMensaje"].Value.ToString();
                //string MensajeErr = cmd.Parameters["@pMensaje_Error"].Value.ToString();

                cnx.Close();
                cnx.Dispose();

                if (Salida == 1)
                {
                    return "1";
                }
                else
                {
                    return MensajeOK;
                }

            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }


        public DataSet Listado_CartonesLeidos()
        {
            DataSet ds = new DataSet();
            try
            {
                //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnString"].ToString()))
                {
                    //asignar los valores proporcionados a estos parámetros sobre la base de orden de los parámetros
                    using (SqlCommand cmd = new SqlCommand("sp_Lectura_Cartones", con))
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
