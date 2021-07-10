using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WcsParis
{
    public partial class FrmMantenedorDTD : Form
    {
        //utilizamos la clase para saltar al siguiente control
        CLS_Utilidades.CLS_SeteaFormatoGrilla _seteaformato = new CLS_Utilidades.CLS_SeteaFormatoGrilla();
        CLS_Utilidades.CLS_Ilumina_Texto _iluminaTexto = new CLS_Utilidades.CLS_Ilumina_Texto();
        CLS_Utilidades.CLS_ValNumero _valnum = new CLS_Utilidades.CLS_ValNumero();

        //registro log
        cRegistroErr RegErrores = new cRegistroErr();

        LGN_Tb_DTD _LGN_Tb_DTD = new LGN_Tb_DTD();
        cENT_Dtd _ENT_Dtd = new cENT_Dtd(); 

        bool flag = false;

        #region
        //**// Crea la Alineacion de la grilla
        enum Alineacion
        {
            Izquierda,
            Centro,
            Derecha
        }

        //**// Limpiar grilla
        private void GrillaLimpia(DataGridView dtg)
        {
            dtg.DataSource = null;
            dtg.Rows.Clear();
            dtg.Columns.Clear();

            _seteaformato.CreaGrillaLimpia(dtg, 0, "Salida", true);
            _seteaformato.CreaGrillaLimpia(dtg, 1, "Dtd", true);
        }

        private void FormatoGrilla(DataGridView dtg)
        {

            //***********************
            //CABECERA DE GRILLA
            //***********************
            //Permite habilitar los formatos del usuario
            DgvDatos.EnableHeadersVisualStyles = false;
            //oculta la columna Default de grilla
            DgvDatos.RowHeadersVisible = false;

            _seteaformato.SeteaFormatoGrilla(dtg, 0, "Salida", 200, true, Alineacion.Izquierda.ToString(), true);
            _seteaformato.SeteaFormatoGrilla(dtg, 1, "Dtd", 200, true, Alineacion.Izquierda.ToString(), true);


            //--- Permite la Seleccion de la Fila Completa
            DgvDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //--- Permite que la grilla no se pueda editar
            DgvDatos.ReadOnly = true;
            //--- desabilita el agrear linea
            DgvDatos.AllowUserToAddRows = false;
            //Permite copiar al Portapapeles (Memoria), para luego pegar... excel, bloc de notas, etc. (solo Dios y SG sabe lo que hace)
            DgvDatos.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            DgvDatos.ColumnHeadersDefaultCellStyle.ForeColor = Color.Navy;

            //***********************
            //DETALLE DE GRILLA
            //***********************
            //cambia el Color de Fondo de la Grilla
            DgvDatos.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 192);
            //cambia el Color de Seleccion
            DgvDatos.DefaultCellStyle.SelectionBackColor = Color.Lime;
            //cambia el Color de fuente
            DgvDatos.DefaultCellStyle.SelectionForeColor = Color.Navy;
            //cambia el Tamaño y Letra de la fuente, color 
            DgvDatos.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8);
            DgvDatos.DefaultCellStyle.ForeColor = Color.Navy;

        }
        #endregion
        public FrmMantenedorDTD()
        {
            InitializeComponent();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea salir?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void LlenarGrilla()
        {
            //lleno dataset
            DataSet dsdatos = new DataSet();
            dsdatos = _LGN_Tb_DTD.Listado_DTD();

            try
            {
                if (dsdatos != null)
                {

                    //Elimina el enlace de datos para poder limpiar
                    this.DgvDatos.DataSource = null;

                    //limpia los datos
                    this.DgvDatos.Rows.Clear();
                    this.DgvDatos.Columns.Clear();

                    //asigna la informacion a la grilla                    
                    this.DgvDatos.DataSource = dsdatos.Tables[0];
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                RegErrores.RegistroLog(ex.Message.ToString() + " funcion LeerEtiquetasDerivadas");
            }

        }

        private void FrmMantenedorDTD_Load(object sender, EventArgs e)
        {
            GrillaLimpia(DgvDatos);
            LlenarGrilla();
            FormatoGrilla(DgvDatos);
        }

        private void DgvDatos_KeyDown(object sender, KeyEventArgs e)
        {
            //suprimo el enter
            e.SuppressKeyPress = true;  
        }

        private void DgvDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                TxtLinea.Text = Convert.ToString(DgvDatos.Rows[e.RowIndex].Cells[0].Value.ToString());
                TxtDtd.Text = Convert.ToString(DgvDatos.Rows[e.RowIndex].Cells[1].Value.ToString());

                TxtLinea.Enabled = false;

                TxtDtd.Focus();

                //quito registro grilla
                DgvDatos.Rows.RemoveAt(e.RowIndex);
                flag = true;
                BtnGuardar.Text = "Editar";
            }
        }

        private void TxtLinea_Enter(object sender, EventArgs e)
        {
            _iluminaTexto.Activa_Texto(TxtLinea);
        }

        private void TxtLinea_Leave(object sender, EventArgs e)
        {
            _iluminaTexto.Desactiva_Texto(TxtLinea);
        }

        private void TxtDtd_Enter(object sender, EventArgs e)
        {
            _iluminaTexto.Activa_Texto(TxtDtd);
        }

        private void TxtDtd_Leave(object sender, EventArgs e)
        {
            _iluminaTexto.Desactiva_Texto(TxtDtd);
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            string res = string.Empty;
            string mod = string.Empty;

            if (string.IsNullOrEmpty(TxtLinea.Text) || (string.IsNullOrEmpty(TxtDtd.Text)))
            {
                MessageBox.Show("Se debe llenar todos los campos solicitados", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TxtLinea.Focus();
                return;
            }

            _ENT_Dtd.IdLinea = Convert.ToInt16(TxtLinea.Text);
            _ENT_Dtd.Location = TxtDtd.Text;

            if (flag)
            {
                if (MessageBox.Show("Desea modificar DTD de salida " + _ENT_Dtd.IdLinea.ToString() + ". ?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    mod = _LGN_Tb_DTD.Actualizar_Tb_DTD(_ENT_Dtd);

                    if (mod == "1")
                    {
                        MessageBox.Show("DTD editada en forma correcta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BorrarCajas();
                        LlenarGrilla();
                        FormatoGrilla(DgvDatos);
                        flag = false;
                        BtnGuardar.Text = "Guardar";
                        return;
                    }
                    else
                    {
                        MessageBox.Show(mod, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                }
                else 
                {
                    BorrarCajas();
                    LlenarGrilla();
                    FormatoGrilla(DgvDatos);                
                }
            }
            else 
            {
                if (MessageBox.Show("Desea agregar DTD a la salida. ?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    res = _LGN_Tb_DTD.Inserta_Tb_DTD(_ENT_Dtd);

                    if (res == "1")
                    {
                        MessageBox.Show("DTD agregada en forma correcta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BorrarCajas();
                        LlenarGrilla();
                        FormatoGrilla(DgvDatos);
                        flag = false;
                        BtnGuardar.Text = "Guardar";
                        return;
                    }
                    else
                    {
                        MessageBox.Show(res, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                else
                {
                    BorrarCajas();
                    LlenarGrilla();
                    FormatoGrilla(DgvDatos);
                }      
            }
        }

        private void BorrarCajas()
        {
            TxtDtd.Text = string.Empty;
            TxtLinea.Text = string.Empty;               
        }

        private void TxtLinea_KeyPress(object sender, KeyPressEventArgs e)
        {
            _valnum.ControlaEntero(TxtLinea, e, 3);
        }
    }
}
