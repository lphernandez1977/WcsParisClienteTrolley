using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//Se utiliza
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

namespace CLS_Utilidades
{
    public class CLS_ValNumero
    {   //
        //El uso de la clase StringBuilder nos ayudara a devolver los mensajes de las validaciones
        public readonly StringBuilder stringBuilder = new StringBuilder();

      //** validara que sea solo numeros
  //      public Boolean ControlaEntero(int tecla, TextBox texto)
        public void ControlaEntero(object sender, KeyPressEventArgs e, int piLargo)
        {
            if ((char.IsDigit(e.KeyChar)) || (e.KeyChar == (char)Keys.Tab) || (e.KeyChar == (char)Keys.Back))
            {
                if (char.IsDigit(e.KeyChar))
                {
                    TextBox txtOTexto = sender as TextBox;
                    if (piLargo + txtOTexto.SelectionLength - txtOTexto.Text.Trim().Length <= 1)
                    {
                        if (piLargo + txtOTexto.SelectionLength - txtOTexto.Text.Trim().Length == 1)
                        {       
                            e.Handled = false;
                            SendKeys.Send("{TAB}");
                        }
                        else
                        {
                            e.Handled = true;
                        }
                    }
                    else
                        e.Handled = false;
                }
                else
                    e.Handled = false;
            }
            else
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    e.Handled = true;
                    SendKeys.Send("{TAB}");
                }
                else
                    e.Handled = true;
            }
        }
        //{
        //    Boolean Resul = true;
        //    try
        //    {

        //        switch (tecla){

        //            case (48 - 57):
        //                switch (tecla)
        //                {
        //                    case (0):
        //                        break;    
        //                }
        //                break;
        //            case (13):
        //                SendKeys.Send("{TAB}");
        //                break;
        //            case (8):


        //                break;

        //        }


        //        string cadena = "0123456789" + (char)8 + (char)13;

        //        //controla el largo del texto
        //        if (!cadena.Contains(tecla.KeyChar)) //el cararcter no esta contenido en en la cadena
        //        {
        //            //texto.Undo();
        //            tecla.Handled = true;
                    
        //        }
        //        else if ((texto.TextLength + 1) == 9) //el cararcter no esta contenido en en la cadena
        //        {
        //            SendKeys.Send("{TAB}");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //Resul = false;
        //    }

        //    return Resul;
        //}

    }

    public class CLS_ValNumeroRut
    {   //
        //El uso de la clase StringBuilder nos ayudara a devolver los mensajes de las validaciones
        public readonly StringBuilder stringBuilder = new StringBuilder();

        public Boolean ValNumeroRut(KeyPressEventArgs tecla, TextBox texto, Boolean decim = true)
        {
            Boolean Resul = false;
            try
            {                
                string cadena = "0123456789kK" + (char)8 + (char)13;

                //controla el largo del texto
                if (!cadena.Contains(tecla.KeyChar)) //el cararcter no esta contenido en en la cadena
                {
                    //texto.Text = "";
                    texto.Undo();
                    tecla.Handled = true;
                    Resul = true;
                }
                else if (texto.TextLength == 9) //el cararcter no esta contenido en en la cadena
                {
                //    texto.Undo();                    
                    Resul = true;
                }
                else if (tecla.KeyChar == (int)System.Convert.ToChar(System.Windows.Forms.Keys.Enter))
                    Resul = true;
            }
            catch (Exception ex)
            {
                Resul = false;
            }
            return Resul;
        }

        public void ControlaRut(KeyPressEventArgs tecla, TextBox texto, Boolean decim = true)
        {
            try
            {
                string cadena = "0123456789kK" + (char)8 + (char)13;

                //controla el largo del texto
                if (!cadena.Contains(tecla.KeyChar)) //el cararcter no esta contenido en en la cadena
                {
                    //texto.Undo();
                    tecla.Handled = true;
                }
                else if ((texto.TextLength + 1) == 9) //el cararcter no esta contenido en en la cadena
                {
                    SendKeys.Send("{TAB}");
                }
                else if (tecla.KeyChar == 13) //el cararcter no esta contenido en en la cadena
                {
                    SendKeys.Send("{TAB}");
                }
            }
            catch (Exception ex)
            {
                //Resul = false;
            }
        }

    }

    public class CLS_ValNumeroCompleto
    {   //
        //El uso de la clase StringBuilder nos ayudara a devolver los mensajes de las validaciones
        public readonly StringBuilder stringBuilder = new StringBuilder();

        public Boolean ValNumeroCompleto(TextBox texto)
        {
            Boolean Resul = true;

            double myNum = 0;
            string c = texto.Text;
            // No es numero
            if (double.TryParse(c, out myNum) == false)
            {
                Resul = true;
            }
            else // es numero
            {
                Resul = false;
            }

            return Resul;
        }

    }

    public class CLS_ValTextoSinCaracteres
    {   //
        //El uso de la clase StringBuilder nos ayudara a devolver los mensajes de las validaciones
        public readonly StringBuilder stringBuilder = new StringBuilder();
        public void ValTextoSinCaracteres(KeyPressEventArgs tecla, TextBox control)
        {
            string cadena = "0123456789" + 
                            "abcdefghijklmnopqrstuvwxyz" +
                            "ABCDEFGHIJKLMNOPQRSTUVWXYZ" +
                            "#." +
                            (char)8 + (char)13;
                
            //controla el largo del texto
            if (!cadena.Contains(tecla.KeyChar)) //el cararcter no esta contenido en en la cadena
            {
                stringBuilder.Clear();
                stringBuilder.Append("Caracter Digitado No Valida");

                control.Text = control.Text;
                tecla.Handled = true;
            }           
        }
    }

    public class CLS_ValidaRut
    {
        //
        //El uso de la clase StringBuilder nos ayudara a devolver los mensajes de las validaciones
        public readonly StringBuilder stringBuilder = new StringBuilder();

        private string _Error;
        private string _Rut;

        public CLS_ValidaRut()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
            /// <summary>
            /// Descripción breve de Collection.
            /// </summary>
        }

        //'Crea un Arreglo con la estructura descrita
        public class ValidaRutCollection : ArrayList
        {
            public enum ValidaRutFiscalFields
            {
                _Error,
                _Rut
            }
        }

        //Property
        public string Error
        {
            get { return _Error; }
            set { _Error = value; }
        }
        //Property
        public string Rut
        {
            get { return _Rut; }
            set { _Rut = value; }
        }

        //Validacion Rut
        public Boolean ValidaRutGral(string Rutt)
        {
            try
            {
                string tmpstr = "";
                string rut = "";
                string valrutmax = "";

                valrutmax = Rutt;
                rut = Rutt;
                int i;
                int largo = 0;
                for (i = 0; i < rut.Length; i++)
                {
                    if (rut.Substring(i, 1) != Convert.ToString(' ') && rut.Substring(i, 1) != Convert.ToString('.') && rut.Substring(i, 1) != Convert.ToString('-'))
                    {
                        tmpstr = tmpstr + rut.Substring(i, 1);
                    }
                }
                rut = tmpstr;
                largo = rut.Length;
                //tmpstr = "";  

                if (largo < 2)
                {
                    stringBuilder.Clear();
                    stringBuilder.Append("Debe ingresar el RUT completo.");

                    return false;
                }

                for (i = 0; rut.Substring(i, 1) == Convert.ToString('0'); i++)
                {
                    for (; i < rut.Length; i++)
                    {
                        tmpstr = tmpstr + rut.Substring(i);
                        rut = tmpstr;
                        largo = rut.Length;
                    }
                }

                if (largo < 2)
                {
                    stringBuilder.Clear();
                    stringBuilder.Append("Debe ingresar el RUT completo.");
                    return false;
                }

                for (i = 0; i < largo; i++)
                {
                    if ((rut.Substring(i, 1) != Convert.ToString('0')) && (rut.Substring(i, 1) != Convert.ToString('1')) && (rut.Substring(i, 1) != Convert.ToString('2')) &&
                        (rut.Substring(i, 1) != Convert.ToString('3')) && (rut.Substring(i, 1) != Convert.ToString('4')) && (rut.Substring(i, 1) != Convert.ToString('5')) &&
                        (rut.Substring(i, 1) != Convert.ToString('6')) && (rut.Substring(i, 1) != Convert.ToString('7')) && (rut.Substring(i, 1) != Convert.ToString('8')) &&
                        (rut.Substring(i, 1) != Convert.ToString('9')) && (rut.Substring(i, 1) != Convert.ToString('k')) && (rut.Substring(i, 1) != Convert.ToString('K')))
                    {
                        stringBuilder.Clear();
                        stringBuilder.Append("El valor ingresado no corresponde a un RUT valido.");
                        return false;
                    }
                }

                string rutMax;
                rutMax = valrutmax;
                tmpstr = "";
                tmpstr = rut.Substring(0, (rut.Length - 1));

                //if ((!(Convert.ToDouble(tmpstr) < 50000000)))
                //{
                //    stringBuilder.Clear();
                //    stringBuilder.Append("El Rut ingresado no corresponde a un RUT de Persona Natural");
                //    return false;
                //}


                string invertido = "";
                int j;
                int cnt;
                for (i = (largo - 1), j = 0; i >= 0; i--, j++)
                {
                    invertido = invertido + rut.Substring(i, 1);
                }

                string drut = "";
                drut = drut + invertido.Substring(0, 1);
                drut = drut + '-';
                cnt = 0;

                for (i = 1, j = 2; i < largo; i++, j++)
                {
                    if (cnt == 3)
                    {
                        drut = drut + '.';
                        j++;
                        drut = drut + invertido.Substring(i, 1);
                        cnt = 1;
                    }
                    else
                    {
                        drut = drut + invertido.Substring(i, 1);
                        cnt++;
                    }
                }

                invertido = "";
                for (i = (drut.Length - 1), j = 0; i >= 0; i--, j++)
                {
                    if (drut.Substring(i) == Convert.ToString('k'))
                        invertido = invertido + 'K';
                    else
                        invertido = invertido + drut.Substring(i, 1);
                }


                Rut = invertido;

                if (!checkDV(rut))
                {
                    stringBuilder.Clear();
                    stringBuilder.Append("El RUT es incorrecto.");
                    return false;
                }

                //limpiamos el largo del String Builder
                stringBuilder.Length = 0;
                return true;
            }
            catch (Exception ex)
            {
                stringBuilder.Clear();
                stringBuilder.Append("El RUT es incorrecto.");
                return false;

            }
        }

        private Boolean checkDV(string crut)
        {
            int largo = crut.Length;
            string rut;
            if (largo < 2)
            {
                return false;
            }
            if (largo > 2)
            {
                rut = crut.Substring(0, largo - 1);
            }
            else
            {
                rut = crut.Substring(0);
            }
            string dv;

            dv = crut.Substring(largo - 1);

            if (!checkCDV(dv))
            {
                return false;
            }

            if (rut == null || dv == null)
            {
                return false;
            }

            string dvr = Convert.ToString('0');
            int suma = 0;
            int mul = 2;
            int res;
            int i;
            for (i = rut.Length - 1; i >= 0; i--)
            {
                suma = suma + Convert.ToInt32(rut.Substring(i, 1)) * mul;
                if (mul == 7)
                {
                    mul = 2;
                }
                else
                {
                    mul++;
                }
            }
            res = suma % 11;
            int dvi;
            if (res == 1)
            {
                dvr = Convert.ToString('k');
            }
            else
            {
                if (res == 0)
                {
                    dvr = Convert.ToString('0');
                }
                else
                {
                    dvi = 11 - res;
                    dvr = dvi + "";
                }
            }

            if (dvr.ToUpper() != dv.ToUpper())
            {
                return false;
            }

            return true;
        }

        private Boolean checkCDV(string dvr)
        {
            string dv = dvr + "";
            if (dv != Convert.ToString('0') && dv != Convert.ToString('1') && dv != Convert.ToString('2') &&
               dv != Convert.ToString('3') && dv != Convert.ToString('4') && dv != Convert.ToString('5') &&
               dv != Convert.ToString('6') && dv != Convert.ToString('7') && dv != Convert.ToString('8') &&
               dv != Convert.ToString('9') && dv != Convert.ToString('k') && dv != Convert.ToString('K'))
            {
                return false;
            }
            return true;
        }
    }
    
    public class CLS_Ilumina_Texto
    {
        public void Activa_Texto(Control control)
        {
            control.BackColor = Color.LightBlue;
        }

        public void Desactiva_Texto(Control control)
        {
            control.BackColor = Color.White;
        }

        public void PintarCajasListas(Control control)
        {
            control.BackColor = Color.LightGoldenrodYellow;
            control.BackColor = Color.LightGoldenrodYellow;
        }

        public void DesactivarCajasListas(Control control)
        {
            control.BackColor = Color.White;
            control.BackColor = Color.White;
        }
    }

    public class CLS_ControlLargo
    {
        //
        //El uso de la clase StringBuilder nos ayudara a devolver los mensajes de las validaciones
        public readonly StringBuilder stringBuilder = new StringBuilder();

        public void ControlLargo(KeyPressEventArgs tecla, TextBox control, int largo, Boolean tab)
        {
            int KeyAscii = (int)System.Convert.ToChar(tecla.KeyChar);


            if (tab == true)
            {
                if (KeyAscii == (int)System.Convert.ToChar(System.Windows.Forms.Keys.Enter))
                {
                    SendKeys.Send("{TAB}");

                    tecla.Handled = true;
                }
                else if (largo == ((control.TextLength) + 1))
                {

                    SendKeys.Send("{TAB}");
                }

            }
            else
            {
                if (KeyAscii == (int)System.Convert.ToChar(System.Windows.Forms.Keys.Enter))
                {
                    SendKeys.Send("{TAB}");

                    tecla.Handled = true;
                }
                else if (largo == ((control.TextLength)))
                {

                    tecla.Handled = true;
                }

            }

        }
    }

    public class CLS_ControlFecha
    {   //
        //El uso de la clase StringBuilder nos ayudara a devolver los mensajes de las validaciones
        public readonly StringBuilder stringBuilder = new StringBuilder();

        public void ControlFecha(KeyPressEventArgs tecla, TextBox control)
        {
            try
            {
                string cadena = "0123456789" + (char)8 + (char)13;
                int largo = 10;

                if (control.Text.Length + 1 <= largo)  //1 Correspon de a la tecal digitada
                {
                    //controla el largo del texto
                    if (!cadena.Contains(tecla.KeyChar)) //el cararcter no esta contenido en en la cadena
                    {
                        tecla.Handled = true;
                    }
                    else if ((largo - control.TextLength == 5) || (largo - control.TextLength == 8))
                    {
                        //validamos que si preciona cualquier tecla distinta 
                        if ((tecla.KeyChar == (char)8) || (tecla.KeyChar == (char)13))
                        {
                            //control.Text = control.Text;
                            //tecla.Handled = true;
                        }
                        else
                        {
                            //recupera la posicion final dentro del control
                            int selStart = control.SelectionStart;

                            //agrega el '/' al control
                            control.Text = control.Text + "/" + tecla.KeyChar.ToString().ToUpper();

                            //controla el largo desde la posicion inicial hasta la ultima digitada
                            string before = control.Text.Substring(0, selStart);
                            //posiciona dentro del control 
                            control.SelectionStart = before.Length + 2;
                            tecla.Handled = true;
                        }
                    }
                }
                else
                {
                    //validamos que si preciona cualquier tecla distinta 
                    if ((tecla.KeyChar != (char)8) && (tecla.KeyChar != (char)13))
                    {
                        control.Text = control.Text;
                        tecla.Handled = true;
                    }
                    else if (tecla.KeyChar == (char)13)
                    {
                        SendKeys.Send("{TAB}");
                        tecla.Handled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                tecla.Handled = false;
            }
        }

        public bool ValidaFecha(TextBox control) 
        {
            Boolean exito = false;
            try 
            {
                //validamos si el texto esta vacio
                if (string.IsNullOrEmpty(control.Text) == false)
                {
                    //validamos si el texot es tipop fecha
                    DateTime dt = Convert.ToDateTime(control.Text);
                    exito = true;
                }
                else
                    exito = true;
            }
            catch (Exception ex)
            {
                exito = false;
            }
            return exito;        
        }
    }

    public class CLS_PresionaTecla
    {   //
        //El uso de la clase StringBuilder nos ayudara a devolver los mensajes de las validaciones
        public readonly StringBuilder stringBuilder = new StringBuilder();

        public void PresionaTecla(KeyPressEventArgs tecla, Control control)
        {
            try
            {
                //validamos que si preciona cualquier tecla distinta 
                if (tecla.KeyChar == (char)13)
                {
                    SendKeys.Send("{TAB}");
                    tecla.Handled = true;
                }                
            }
            catch (Exception ex)
            {
                tecla.Handled = false;
            }
        }
    }

    public class CLS_SeteaFormatoGrilla
    {   //
        //El uso de la clase StringBuilder nos ayudara a devolver los mensajes de las validaciones
        public readonly StringBuilder stringBuilder = new StringBuilder();

        //**// Crea el Formato de la grilla
        public void SeteaFormatoGrilla(DataGridView dtg, int Col, string TextoCabecera, int LargoCampo, bool Visible, 
            string Align, bool negrita)
        {
            //**//NOTA: la configuracion de la grilla debe realizar de la misma forma que entrega el Arreglo
            dtg.Columns[Col].HeaderText = TextoCabecera;
            dtg.Columns[Col].Visible = Visible;

            if (Align.ToString() == "Izquierda")
                dtg.Columns[Col].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            if (Align.ToString() == "Centro")
                dtg.Columns[Col].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            if (Align.ToString() == "Derecha")
                dtg.Columns[Col].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        
            dtg.Columns[Col].Width = LargoCampo;
            //dtg.Columns[Col].HeaderCell.Style.ForeColor = Color.Navy;
            if (negrita == true )
                dtg.Columns[Col].HeaderCell.Style.Font = new Font("Verdana", 8, FontStyle.Bold);
            else
                dtg.Columns[Col].HeaderCell.Style.Font = new Font("Verdana", 8);

        }

        public void CreaGrillaLimpia(DataGridView dtg, int Col, string TextoCabecera, bool Visible)
        {
            //**//NOTA: la configuracion de la grilla debe realizar de la misma forma que entrega el Arreglo
            dtg.Columns.Insert(Col, new DataGridViewTextBoxColumn());
            dtg.Columns[Col].Visible = Visible;
            dtg.Columns[Col].Name = TextoCabecera;
            dtg.Columns[Col].HeaderCell.Style.Font = new Font("Verdana", 8);

        }



    }

    //---COPIA GRILLA A MEMORIA
    public class CLS_GridtoClipboard
    {
        //El uso de la clase StringBuilder nos ayudara a devolver los mensajes de las validaciones
        public readonly StringBuilder stringBuilder = new StringBuilder();

        //**// Copia a Memoria Grilla
        public void GridtoClipboard(string NombreArchivo, DataGridView dgv)
        {
            try
            {
                string Ruta_Archivo = @"C:\DptoInfAPPCRoyal\"; // + NombreArchivo.ToString();
                //validamos que si existe el directorio o no
                System.IO.DirectoryInfo dirResp = new System.IO.DirectoryInfo(Ruta_Archivo);

                //si no existe se crea
                if (!dirResp.Exists)
                {
                    dirResp.Create();
                }

                //Crear Objeto de texto;
                var objwritter = new System.IO.StreamWriter(Ruta_Archivo + NombreArchivo.ToString());

                ////------------------------------------                
                //  Agrega la Cabecera 
                ////------------------------------------
                foreach (DataGridViewColumn column in dgv.Columns)
                {
                    //validamos si esta visible la columna
                    if (column.Visible == true)
                        //Escribe en el objeto de texto
                        objwritter.Write(column.HeaderText.ToString() + "\t");
                }
                // Salto de Linea
                objwritter.WriteLine("");

                ////------------------------------------                
                //  Agrega la Detalle
                ////------------------------------------                
                for (int fila = 0; fila < dgv.Rows.Count; fila++)
                {
                    for (int colum = 0; colum < dgv.Columns.Count; colum++)
                    {
                        //validamos si esta visible la columna
                        if (dgv.Columns[colum].Visible == true)
                            //Escribe en el objeto de texto
                            objwritter.Write(dgv.Rows[fila].Cells[colum].Value.ToString() + "\t");
                    }
                    // Salto de Linea
                    objwritter.WriteLine("");
                }
                //Cierra de texto
                objwritter.Close();

                //Abre Objeto de Lectura
                System.IO.StreamReader sr = new System.IO.StreamReader(Ruta_Archivo + NombreArchivo.ToString());
                //Lee todo el Objeto y lo copia en Memoria
                Clipboard.SetText(sr.ReadToEnd());
                //Cierre Objeto de Lectura
                sr.Close();
                //Destrube Objeto de Lectura
                sr.Dispose();
            }
            catch (Exception ex)
            {
                stringBuilder.Clear();
                stringBuilder.Append("Error a Copiar en Memoria");
            }
        }
    }

    public class CLS_Okidata
    {
        //tamaño fuentes okidata
        public string TamFuente(int tamano)
        {
            string nl = string.Empty;
            switch (tamano)
            {
                case 10:
                    nl = Convert.ToChar(18).ToString(); //10                                    
                    break;

                case 12:
                    nl = Convert.ToChar(27).ToString() + Convert.ToChar(58).ToString(); //12
                    break;

                case 15:
                    nl = Convert.ToChar(27).ToString() + Convert.ToChar(103).ToString(); //15
                    break;

                case 17:
                    nl = Convert.ToChar(27).ToString() + Convert.ToChar(15).ToString();//17
                    break;

                case 18:
                    nl = Convert.ToChar(12).ToString(); //Salto de Pagina
                    break;
            }

            return nl;

        }
    
    
    }


        


}
