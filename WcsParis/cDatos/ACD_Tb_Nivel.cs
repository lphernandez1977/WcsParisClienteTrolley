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
    public class ACD_Tb_Nivel
    {
        //public List<cTb_Nivel> RecuperaListadoNivel()
        //{
        //    try
        //    {
        //        //Declaramos una lista del objeto ENT_Password la cual será la encargada de
        //        //regresar una colección de los elementos que se obtengan de la BD
        //        //
        //        //La lista substituye a DataTable utilizado en el proyecto de ejemplo
        //        List<cTb_Nivel> List_Nivel = new List<cTb_Nivel>();

        //        //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
        //        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnString"].ToString()))
        //        {
        //            //asignar los valores proporcionados a estos parámetros sobre la base de orden de los parámetros
        //            using (SqlCommand cmd = new SqlCommand("sp_selec_Nivel", con))
        //            {
        //                cmd.CommandType = System.Data.CommandType.StoredProcedure;

        //                //abrimos conexion
        //                con.Open();
   
        //                SqlDataReader dataReader = cmd.ExecuteReader();
        //                //Preguntamos si el DataReader fue devuelto con datos
        //                while (dataReader.Read())
        //                {
        //                    //
        //                    //Instanciamos al objeto Eproducto para llenar sus propiedades
        //                    cTb_Nivel Nivel = new cTb_Nivel
        //                    {
        //                        IdNivel = Convert.ToInt32(dataReader["id_nivel"]),
        //                        Nom_Nivel = Convert.ToString(dataReader["nom_nivel"]),
        //                    };
        //                    List_Nivel.Add(Nivel);
        //                }
        //                return List_Nivel;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}
    }
}
