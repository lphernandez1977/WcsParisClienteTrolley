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
    public partial class FrmMantenedorTiendas : Form
    {
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

            _seteaformato.CreaGrillaLimpia(dtg, 0, "N°", true);
            _seteaformato.CreaGrillaLimpia(dtg, 1, "Nombre", true);
            _seteaformato.CreaGrillaLimpia(dtg, 2, "Alias", true);
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

            _seteaformato.SeteaFormatoGrilla(dtg, 0, "N°", 80, false, Alineacion.Derecha.ToString(), true);
            _seteaformato.SeteaFormatoGrilla(dtg, 1, "Nombre", 200, true, Alineacion.Izquierda.ToString(), true);
            _seteaformato.SeteaFormatoGrilla(dtg, 2, "Alias", 200, true, Alineacion.Izquierda.ToString(), true);

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


        public FrmMantenedorTiendas()
        {
            InitializeComponent();
        }
        //utilizamos la clase para saltar al siguiente control
        CLS_Utilidades.CLS_SeteaFormatoGrilla _seteaformato = new CLS_Utilidades.CLS_SeteaFormatoGrilla();
        CLS_Utilidades.CLS_Ilumina_Texto _iluminaTexto = new CLS_Utilidades.CLS_Ilumina_Texto();
        CLS_Utilidades.CLS_ValNumero _valnum = new CLS_Utilidades.CLS_ValNumero();

        ENT_Tb_Tiendas eTiendas = new ENT_Tb_Tiendas();
        LGN_Tb_Tiendas lgnTiendas = new LGN_Tb_Tiendas();
        bool flag = false;

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            string res = string.Empty;

            eTiendas.Num_Tienda = Convert.ToInt32(TxtNumTienda.Text);
            eTiendas.Nom_Tienda = TxtNomTienda.Text;
            eTiendas.Alias_Tienda = TxtNomCortoTienda.Text;


            if ((string.IsNullOrEmpty(TxtNumTienda.Text)) ||
                (string.IsNullOrEmpty(TxtNomTienda.Text)) ||
                (string.IsNullOrEmpty(TxtNomCortoTienda.Text)))
            {
                MessageBox.Show("Debe llenar todos los campos solicitados", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TxtNumTienda.Focus();
                return;
            }
            else
            {

                if (flag)
                {
                    res = lgnTiendas.Editar_Tiendas(eTiendas);

                    if (res == "1")
                    {
                        MessageBox.Show("Tienda editada en forma correcta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BorrarCajas();
                        LlenarGrilla();
                        FormatoGrilla(DgvDatos);       
                        TxtNumTienda.Focus();
                        flag = false;
                        BtnGuardar.Text = "Guardar";
                        return;
                    }
                    else
                    {
                        MessageBox.Show(res, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                }
                else 
                {
                    res = lgnTiendas.Inserta_Tiendas(eTiendas);
                    if (res == "1")
                    {
                        MessageBox.Show("Tienda creada en forma correcta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BorrarCajas();
                        LlenarGrilla();
                        FormatoGrilla(DgvDatos);
                        TxtNumTienda.Focus();
                        return;
                    }
                    else
                    {
                        MessageBox.Show(res, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                
                }
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea salir?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void TxtNumTienda_Enter(object sender, EventArgs e)
        {
            _iluminaTexto.Activa_Texto(TxtNumTienda);
        }

        private void TxtNomTienda_Enter(object sender, EventArgs e)
        {
            _iluminaTexto.Activa_Texto(TxtNomTienda);
        }

        private void TxtNomCortoTienda_Enter(object sender, EventArgs e)
        {
            _iluminaTexto.Activa_Texto(TxtNomCortoTienda);
        }

        private void TxtNumTienda_Leave(object sender, EventArgs e)
        {
            _iluminaTexto.Desactiva_Texto(TxtNumTienda);
        }

        private void TxtNomTienda_Leave(object sender, EventArgs e)
        {
            _iluminaTexto.Desactiva_Texto(TxtNomTienda);
        }

        private void TxtNomCortoTienda_Leave(object sender, EventArgs e)
        {
            _iluminaTexto.Desactiva_Texto(TxtNomTienda);
        }

        private void FrmMantenedorTiendas_Load(object sender, EventArgs e)
        {
            GrillaLimpia(DgvDatos);
            LlenarGrilla();
            FormatoGrilla(DgvDatos);
        }

        private void TxtNumTienda_KeyPress(object sender, KeyPressEventArgs e)
        {
            _valnum.ControlaEntero(TxtNumTienda, e, 3);
        }

        private void LlenarGrilla()
        {

            DataSet dsdatos = new DataSet();
            //lleno dataset
            dsdatos = lgnTiendas.Listado_Tiendas();

            try
            {
                if (dsdatos != null)
                {
                    //abrir formulario de Carga
                    //FrmEspere.AbrirVentanaCarga(FrmEspere);

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

        private void DgvDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                TxtNumTienda.Text = Convert.ToString(DgvDatos.Rows[e.RowIndex].Cells[0].Value.ToString());
                TxtNumTienda.Enabled = false;
                TxtNomTienda.Text = Convert.ToString(DgvDatos.Rows[e.RowIndex].Cells[1].Value.ToString());
                TxtNomCortoTienda.Text = Convert.ToString(DgvDatos.Rows[e.RowIndex].Cells[2].Value.ToString());
                TxtNomTienda.Focus();
                //quito registro grilla
                DgvDatos.Rows.RemoveAt(e.RowIndex);
                flag = true;
                BtnGuardar.Text = "Editar";
            }
        }

        private void BorrarCajas() 
        {
            TxtNumTienda.Text = string.Empty;
            TxtNomTienda.Text = string.Empty;
            TxtNomCortoTienda.Text = string.Empty;
        
        }
    }
}
