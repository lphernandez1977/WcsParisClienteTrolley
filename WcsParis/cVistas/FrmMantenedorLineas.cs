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
    public partial class FrmMantenedorLineas : Form
    {
        //utilizamos la clase para saltar al siguiente control
        CLS_Utilidades.CLS_SeteaFormatoGrilla _seteaformato = new CLS_Utilidades.CLS_SeteaFormatoGrilla();
        CLS_Utilidades.CLS_Ilumina_Texto _iluminaTexto = new CLS_Utilidades.CLS_Ilumina_Texto();
        CLS_Utilidades.CLS_ValNumero _valnum = new CLS_Utilidades.CLS_ValNumero();

        cTb_Lineas eLineas = new cTb_Lineas();
        LGN_Tb_Lineas lgnLineas = new LGN_Tb_Lineas();
        bool flag = false;

        //Grilla
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
            _seteaformato.CreaGrillaLimpia(dtg, 1, "Estado", true);
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
            _seteaformato.SeteaFormatoGrilla(dtg, 1, "Estado", 200, true, Alineacion.Izquierda.ToString(), true);
 

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

        public FrmMantenedorLineas()
        {
            InitializeComponent();
        }

        private void FrmMantenedorLineas_Load(object sender, EventArgs e)
        {
            GrillaLimpia(DgvDatos);
            LlenarGrilla();
            FormatoGrilla(DgvDatos);
            LlenarCboEstado();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea salir?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void TxtNumTienda_KeyPress(object sender, KeyPressEventArgs e)
        {
            _valnum.ControlaEntero(TxtSalida, e, 3);
        }

        private void LlenarCboEstado()
        {
            List<cENT_Lista> lista = new List<cENT_Lista>();

            lista.Add(new cENT_Lista("Seleccionar Estado", 0));
            lista.Add(new cENT_Lista("Activo", 1));
            lista.Add(new cENT_Lista("No Activo", 2));


            //Vaciar comboBox
            this.CboEstado.DataSource = null;

            //Asignar la propiedad DataSource
            this.CboEstado.DataSource = lista;

            //Indicar qué propiedad se verá en la lista
            this.CboEstado.DisplayMember = "Name";

            //Indicar qué valor tendrá cada ítem
            this.CboEstado.ValueMember = "Value";
        }

        private void LlenarGrilla()
        {
            //lleno dataset
            DataSet dsdatos = new DataSet();          
            dsdatos = lgnLineas.Listado_Salidas();

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

            }

        }

        private void DgvDatos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {


    
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            string res = string.Empty;
            eLineas.IdLinea = Convert.ToInt32(TxtSalida.Text);
            
            if (CboEstado.SelectedIndex == 0) { MessageBox.Show("Debe seleccionar un estado valido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            //valida estado
            if (CboEstado.SelectedIndex == 1) { eLineas.IdEstado = 1; eLineas.NomEstado = "Activo"; }
            if (CboEstado.SelectedIndex == 2) { eLineas.IdEstado = 2; eLineas.NomEstado = "No Activo";  }


            if (string.IsNullOrEmpty(TxtSalida.Text))
            {
                MessageBox.Show("Se debe llenar todos los campos solicitados", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TxtSalida.Focus();
                return;
            }
            else
            {

                if (flag)
                {
                    //editar usuarios
                    res = lgnLineas.Editar_Tb_Salidas(eLineas);

                    if (res == "1")
                    {
                        MessageBox.Show("Salida editada en forma correcta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BorrarCajas();
                        LlenarGrilla();
                        FormatoGrilla(DgvDatos);       
                        LlenarCboEstado();
                        CboEstado.Focus();
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
                    //crear nuevos usuarios
                    res = lgnLineas.Inserta_Tb_Salidas(eLineas);

                    if (res == "1")
                    {
                        MessageBox.Show("Salida creada en forma correcta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BorrarCajas();
                        LlenarGrilla();
                        FormatoGrilla(DgvDatos);                     
                        LlenarCboEstado();
                        TxtSalida.Focus();
                        return;
                    }
                    else
                    {
                        MessageBox.Show(res, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }
        }

        private void BorrarCajas() 
        {
            TxtSalida.Text = string.Empty;
        }

        private void DgvDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                TxtSalida.Text = DgvDatos.Rows[e.RowIndex].Cells[0].Value.ToString();
                TxtSalida.Enabled = false;

                if (DgvDatos.Rows[e.RowIndex].Cells[1].Value.ToString() == "Activo")
                {
                    CboEstado.SelectedValue = 1;
                }
                else
                {
                    CboEstado.SelectedValue = 2;
                }

                CboEstado.Focus();

                //quito registro grilla
                DgvDatos.Rows.RemoveAt(e.RowIndex);
                flag = true;
                BtnGuardar.Text = "Editar";
            }
        }
    }
}
