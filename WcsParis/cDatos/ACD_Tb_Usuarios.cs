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
    public class ACD_Tb_Usuarios
    {
        public string Inserta_Usuarios(cTb_Usuarios oTb_Usuarios)
        {
            int res = 0;
            try
            {
                SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnString"].ToString());
                SqlCommand cmd = new SqlCommand("sp_Insert_Usuarios", cnx);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@pNom_Usuario", System.Data.SqlDbType.VarChar,20).Value = oTb_Usuarios.Nom_Usuario;
                cmd.Parameters.Add("@pPass", System.Data.SqlDbType.VarChar,20).Value = oTb_Usuarios.Contrasenia;
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

        public DataSet Listado_Usuarios()
        {
            DataSet ds = new DataSet();
            try
            {
                //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnString"].ToString()))
                {
                    //asignar los valores proporcionados a estos parámetros sobre la base de orden de los parámetros
                    using (SqlCommand cmd = new SqlCommand("sp_selec_usuarios", con))
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

        public cTb_Usuarios Selecciona_Usuario(cTb_Usuarios oUser)
        {
            string MensajeSp = string.Empty;

            try
            {
                //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnString"].ToString()))
                {
                    //asignar los valores proporcionados a estos parámetros sobre la base de orden de los parámetros
                    using (SqlCommand cmd = new SqlCommand("sp_selec_usuario", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add("@pUsuario", System.Data.SqlDbType.Text).Value = oUser.Nom_Usuario;
                        cmd.Parameters.Add("@pClave", System.Data.SqlDbType.Text).Value = oUser.Contrasenia;

                        //parametros de salida
                        //cmd.Parameters.Add("@vSalida", SqlDbType.VarChar, 10).Direction = ParameterDirection.Output;

                        //abrimos conexion
                        con.Open();
            
                        //ejecuto query
                        SqlDataReader dataReader = cmd.ExecuteReader();
                        
                        //Preguntamos si el DataReader fue devuelto con datos
                        while (dataReader.Read())
                        {
                            //Instanciamos al objeto Eproducto para llenar sus propiedades
                            cTb_Usuarios _cTb_Usuarios = new cTb_Usuarios
                            {
                                Nom_Usuario = dataReader["Nom_Usuario"].ToString(),
                                Nivel = Convert.ToChar(dataReader["Nivel"]),
                                Nom_Nivel = dataReader["NAcceso"].ToString(),
                                Mensaje = dataReader["Mensaje"].ToString()
                            };
                                                                                   
                               return _cTb_Usuarios;
                        }
                    }
                }
                //se define que si no hay datos envia null
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string Actualiza_Passwword(cTb_Usuarios oTb_Usuarios)
        {
            int res = 0;
            try
            {
                SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnString"].ToString());
                SqlCommand cmd = new SqlCommand("sp_Modifica_Password", cnx);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@pNom_Usuario", System.Data.SqlDbType.VarChar, 20).Value = oTb_Usuarios.Nom_Usuario;
                cmd.Parameters.Add("@pPassOld", System.Data.SqlDbType.VarChar, 20).Value = oTb_Usuarios.Contrasenia;
                cmd.Parameters.Add("@pPassNew", System.Data.SqlDbType.VarChar, 20).Value = oTb_Usuarios.NuevaContrasenia;
                cmd.Parameters.Add("@pOpcion", System.Data.SqlDbType.VarChar, 20).Value = oTb_Usuarios.Mensaje;
         
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

        //public string UpdateDireccionServTecnico(ENT_SstDireccionServicioTecnico _ent_SstDireccionServicioTecnico)
        //{
        //    int res = 0;
        //    try
        //    {
        //        SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnString"].ToString());
        //        SqlCommand cmd = new SqlCommand("SP_Actualiza_Direccion_ServTec", cnx);
        //        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //        cmd.Parameters.Add("@pRut", System.Data.SqlDbType.Float).Value = _ent_SstDireccionServicioTecnico.RutSTA;
        //        cmd.Parameters.Add("@pCorrelativoDir", System.Data.SqlDbType.Int).Value = _ent_SstDireccionServicioTecnico.CorrelativoDir;
        //        cmd.Parameters.Add("@pDireccion", System.Data.SqlDbType.Char).Value = _ent_SstDireccionServicioTecnico.DireccionSTA;
        //        cmd.Parameters.Add("@pTelefono1", System.Data.SqlDbType.Char).Value = _ent_SstDireccionServicioTecnico.Telefono1STA;
        //        cmd.Parameters.Add("@pTelefono2", System.Data.SqlDbType.Char).Value = _ent_SstDireccionServicioTecnico.Telefono2STA;
        //        cmd.Parameters.Add("@pTelefono3", System.Data.SqlDbType.Char).Value = _ent_SstDireccionServicioTecnico.Telefono3STA;
        //        cmd.Parameters.Add("@pIdRegion", System.Data.SqlDbType.Int).Value = _ent_SstDireccionServicioTecnico.IdRegion;
        //        cmd.Parameters.Add("@pIdCiudad", System.Data.SqlDbType.Int).Value = _ent_SstDireccionServicioTecnico.IdCiudad;
        //        cmd.Parameters.Add("@pIdComuna", System.Data.SqlDbType.Int).Value = _ent_SstDireccionServicioTecnico.IdComuna;
        //        cmd.Parameters.Add("@pEstadoSTA", System.Data.SqlDbType.Int).Value = _ent_SstDireccionServicioTecnico.EstadoSTA;
        //        cnx.Open();
        //        res = cmd.ExecuteNonQuery();
        //        cnx.Close();
        //        return Convert.ToString(res);
        //    }
        //    catch (Exception ex)
        //    {
        //        string msj = string.Empty;
        //        msj = ex.Message.ToString();
        //        return msj;
        //    }

        //}

        //public DataSet Selecciona_DirServTec(double rutsta)
        //{
        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
        //        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnString"].ToString()))
        //        {
        //            //asignar los valores proporcionados a estos parámetros sobre la base de orden de los parámetros
        //            using (SqlCommand cmd = new SqlCommand("SP_Selecciona_DirServTec", con))
        //            {
        //                cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //                cmd.Parameters.Add("@pRut", System.Data.SqlDbType.Float).Value = rutsta;
        //                //abrimos conexion
        //                con.Open();
        //                //Ejecutamos Procedimiento                        
        //                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //                //llenar el conjunto de datos utilizando los valores predeterminados para los nombres de DataTable, etc 
        //                adapter.Fill(ds);
        //                //Cierre conexion
        //                con.Close();
        //                //retorna los datos
        //                return ds;
        //            }
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        ds = null;
        //    }
        //    //devolver el conjunto de datos
        //    return ds;
        //}

        //public ENT_SstDireccionServicioTecnico Selecciona_DireccionServTecxNombre(string nombre)
        //{
        //    try
        //    {
        //        //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
        //        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnString"].ToString()))
        //        {
        //            //asignar los valores proporcionados a estos parámetros sobre la base de orden de los parámetros
        //            using (SqlCommand cmd = new SqlCommand("SP_Selecciona_DirServTecxNombre", con))
        //            {
        //                cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //                cmd.Parameters.Add("@pNom", System.Data.SqlDbType.Text).Value = nombre;
        //                //abrimos conexion
        //                con.Open();

        //                SqlDataReader dataReader = cmd.ExecuteReader();
        //                //Preguntamos si el DataReader fue devuelto con datos
        //                while (dataReader.Read())
        //                {
        //                    //
        //                    //Instanciamos al objeto Eproducto para llenar sus propiedades
        //                    ENT_SstDireccionServicioTecnico _ent_SstDireccionServicioTecnico = new ENT_SstDireccionServicioTecnico
        //                    {
        //                        RutSTA = Convert.ToInt32(dataReader["RutSTA"]),
        //                        CorrelativoDir = Convert.ToChar(dataReader["CorrelativoDir"]),
        //                        DireccionSTA = Convert.ToString(dataReader["DireccionSTA"]),
        //                        Telefono1STA = Convert.ToString(dataReader["Telefono1STA"]),
        //                        Telefono2STA = Convert.ToString(dataReader["Telefono2STA"]),
        //                        Telefono3STA = Convert.ToString(dataReader["Telefono3STA"]),
        //                        IdRegion = Convert.ToInt32(dataReader["IdRegion"]),
        //                        IdCiudad = Convert.ToInt32(dataReader["IdCiudad"]),
        //                        IdComuna = Convert.ToInt32(dataReader["IdComuna"]),
        //                        EstadoSTA = Convert.ToInt32(dataReader["EstadoSTA"])
        //                    };
        //                    return _ent_SstDireccionServicioTecnico;
        //                }

        //            }
        //        }
        //        //se define que si no hay datos envia null
        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}
    }
}
