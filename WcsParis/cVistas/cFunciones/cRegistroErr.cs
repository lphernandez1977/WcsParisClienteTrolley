using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

namespace WcsParis
{
    public class cRegistroErr
    {
        public void RegistroLog(string log)
        {
            string ruta = string.Empty;
            string fichero = string.Empty;
            string Carpeta = string.Empty;
            string RutaFinal = string.Empty;
            string path = string.Empty;

            try
            {
                ruta = Directory.GetCurrentDirectory();
                Carpeta = "RegistroErrores";
                fichero = "Log_Errores " + DateTime.Now.ToString("dd-MM-yyyy") + ".txt";

                path = ruta + @"\" + Carpeta;

                RutaFinal = ruta + @"\" + Carpeta + @"\" + fichero;

                if (Directory.Exists(path))
                {
                    StreamWriter oSW = File.AppendText(RutaFinal);
                    string linea = Convert.ToString(DateTime.Now) + (char)9 + log;
                    oSW.WriteLine(linea);
                    oSW.Flush();
                    oSW.Close();
                }

                else
                {
                    DirectoryInfo di = Directory.CreateDirectory(path);

                    StreamWriter oSW = new StreamWriter(RutaFinal);
                    String Linea = Convert.ToString(DateTime.Now) + (char)9 + log;
                    oSW.WriteLine(Linea);
                    oSW.Flush();
                    oSW.Close();
                }

                //return true;  
            }
            catch (Exception ex)
            {
                RegistroLog(ex.Message.ToString());
                //return false;
            }

        }
    }
}
