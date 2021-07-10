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
    public partial class FrmConfSalTiendas : Form
    {
        public FrmConfSalTiendas()
        {
            InitializeComponent();
        }
        //utilizamos la clase para saltar al siguiente control
        CLS_Utilidades.CLS_SeteaFormatoGrilla _seteaformato = new CLS_Utilidades.CLS_SeteaFormatoGrilla();
        CLS_Utilidades.CLS_Ilumina_Texto _iluminaTexto = new CLS_Utilidades.CLS_Ilumina_Texto();
        cRegistroErr LogError = new cRegistroErr();

        cTb_Lineas _ENT_Lineas = new cTb_Lineas();
        ENT_Tb_Tiendas _ENT_Tb_Tiendas = new ENT_Tb_Tiendas(); 
        LGN_Tb_Tiendas _LGN_Tb_Tiendas = new LGN_Tb_Tiendas();
        LGN_Tb_Lineas _LGN_Tb_Lineas = new LGN_Tb_Lineas();

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

            _seteaformato.CreaGrillaLimpia(dtg, 0, "N° Tienda", true);
            _seteaformato.CreaGrillaLimpia(dtg, 1, "Tienda", true);
            _seteaformato.CreaGrillaLimpia(dtg, 2, "Alias", true);
            //_seteaformato.CreaGrillaLimpia(dtg, 3, "Salida", true);   
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

            _seteaformato.SeteaFormatoGrilla(dtg, 0, "N° Tienda", 100, false, Alineacion.Derecha.ToString(), true);
            _seteaformato.SeteaFormatoGrilla(dtg, 1, "Tienda", 100, true, Alineacion.Izquierda.ToString(), true);
            _seteaformato.SeteaFormatoGrilla(dtg, 2, "Alias", 100, true, Alineacion.Izquierda.ToString(), true);
            //_seteaformato.SeteaFormatoGrilla(dtg, 3, "Salida", 142, true, Alineacion.Izquierda.ToString(), true);
 
            //--- Permite la Seleccion de la Fila Completa
            DgvDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //--- Permite que la grilla no se pueda editar
            DgvDatos.ReadOnly = false;
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
            DgvDatos.MultiSelect = false;

        }
        #endregion

        //Grilla2
        #region

        //**// Limpiar grilla
        private void GrillaLimpia2(DataGridView dtg)
        {
            dtg.DataSource = null;
            dtg.Rows.Clear();
            dtg.Columns.Clear();

            _seteaformato.CreaGrillaLimpia(dtg, 0, "Salida", true);
            _seteaformato.CreaGrillaLimpia(dtg, 1, "Alias", true);
            _seteaformato.CreaGrillaLimpia(dtg, 2, "Tienda", true);
            _seteaformato.CreaGrillaLimpia(dtg, 3, "idestado", false);
            _seteaformato.CreaGrillaLimpia(dtg, 4, "Estado", true);
        }

        private void FormatoGrilla2(DataGridView dtg)
        {

            //***********************
            //CABECERA DE GRILLA
            //***********************
            //Permite habilitar los formatos del usuario
            DgvSalidas.EnableHeadersVisualStyles = false;
            //oculta la columna Default de grilla
            DgvSalidas.RowHeadersVisible = false;

            _seteaformato.SeteaFormatoGrilla(dtg, 0, "Salida", 50, true, Alineacion.Derecha.ToString(), true);
            _seteaformato.SeteaFormatoGrilla(dtg, 1, "Alias", 80, true, Alineacion.Izquierda.ToString(), true);
            _seteaformato.SeteaFormatoGrilla(dtg, 2, "Tienda", 100, true, Alineacion.Izquierda.ToString(), true);
            _seteaformato.SeteaFormatoGrilla(dtg, 3, "idestado", 142,false, Alineacion.Izquierda.ToString(), true);
            _seteaformato.SeteaFormatoGrilla(dtg, 4, "Estado", 100, true, Alineacion.Izquierda.ToString(), true);

            //--- Permite la Seleccion de la Fila Completa
            DgvSalidas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //--- Permite que la grilla no se pueda editar
            DgvSalidas.ReadOnly = true;
            //--- desabilita el agrear linea
            DgvSalidas.AllowUserToAddRows = false;
            //Permite copiar al Portapapeles (Memoria), para luego pegar... excel, bloc de notas, etc. (solo Dios y SG sabe lo que hace)
            DgvSalidas.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            DgvSalidas.ColumnHeadersDefaultCellStyle.ForeColor = Color.Navy;

            //***********************
            //DETALLE DE GRILLA
            //***********************
            //cambia el Color de Fondo de la Grilla
            DgvSalidas.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 192);
            //cambia el Color de Seleccion
            DgvSalidas.DefaultCellStyle.SelectionBackColor = Color.Lime;
            //cambia el Color de fuente
            DgvSalidas.DefaultCellStyle.SelectionForeColor = Color.Navy;
            //cambia el Tamaño y Letra de la fuente, color 
            DgvSalidas.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8);
            DgvSalidas.DefaultCellStyle.ForeColor = Color.Navy;
            DgvSalidas.MultiSelect = false;

        }
        #endregion

        private void FrmConfSalTiendas_Load(object sender, EventArgs e)
        {
            GrillaLimpia(DgvDatos);
            LlenarGrilla();
            LlenarCboGrilla();
            FormatoGrilla(DgvDatos);

            GrillaLimpia2(DgvSalidas);
            LlenarGrilla2();
            FormatoGrilla2(DgvSalidas);
        }

        private void LlenarCboGrilla() 
        {
            DataSet dscombos = new DataSet();
            dscombos = _LGN_Tb_Lineas.Listado_SalidasActivas();

            DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();
            cmb.DataSource = dscombos.Tables[0];
            cmb.DisplayMember = "IdLinea";
            cmb.ValueMember = "IdLinea";
            cmb.HeaderText = "Salidas Disponibles ";
            //cambia el Tamaño y Letra de la fuente, color 
            cmb.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 8);
            cmb.DefaultCellStyle.ForeColor = Color.Navy;
            cmb.Width = 120;
            cmb.Name = "cmb";
            cmb.MaxDropDownItems = DgvDatos.RowCount;
            DgvDatos.Columns.Insert(3, cmb);          
            DgvDatos.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;        
        }

        private void LlenarGrilla()
        {
            DataSet dsdatos = new DataSet();
            //lleno dataset
            dsdatos = _LGN_Tb_Tiendas.Listado_Tiendas_2();            
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
                    //cierra formulario de Carga
                    //FrmEspere.CerrarVentanaCarga(FrmEspere);  

                }
            }
            catch (Exception ex)
            {
                //FrmEspere.CerrarVentanaCarga(FrmEspere);
            }

        }

        private void LlenarGrilla2()
        {
            DataSet dsdatos = new DataSet();
            //lleno dataset
            dsdatos = _LGN_Tb_Tiendas.Listado_LineasxTienda();
            try
            {
                if (dsdatos != null)
                {
                    //Elimina el enlace de datos para poder limpiar
                    this.DgvSalidas.DataSource = null;

                    //limpia los datos
                    this.DgvSalidas.Rows.Clear();
                    this.DgvSalidas.Columns.Clear();

                    //asigna la informacion a la grilla                    
                    this.DgvSalidas.DataSource = dsdatos.Tables[0];
                }
                else
                {
                    //cierra formulario de Carga
                    //FrmEspere.CerrarVentanaCarga(FrmEspere);  

                }
            }
            catch (Exception ex)
            {
                //FrmEspere.CerrarVentanaCarga(FrmEspere);
            }

        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea salir?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            
            string res = string.Empty;
            int cont = 0;
            int comp = 0;
            //cantidad lineas
            comp = DgvDatos.RowCount;

            if (MessageBox.Show("Desea agregar tienda seleccionada a Salidas ?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                try
                {
                    foreach (DataGridViewRow fila in DgvDatos.Rows)
                    {
                        _ENT_Tb_Tiendas.Num_Tienda = Convert.ToInt32(fila.Cells[0].Value.ToString());
                        _ENT_Tb_Tiendas.Alias_Tienda = fila.Cells[2].Value.ToString();

                        if (fila.Cells[3].Value == null)
                        {
                            _ENT_Lineas.IdLinea = 0;
                        }
                        else
                        {
                            _ENT_Lineas.IdLinea = Convert.ToInt32(fila.Cells[3].Value.ToString());
                        }

                        if (_ENT_Lineas.IdLinea != 0)
                        {
                            res = _LGN_Tb_Lineas.ConfNuevasSalidas(_ENT_Lineas, _ENT_Tb_Tiendas);
                            cont = cont + 1;
                        }
                    }

                    if (cont >= 1)
                    {
                        MessageBox.Show("Fueron modificados los registros de lineas, favor revisar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GrillaLimpia(DgvDatos);
                        LlenarGrilla();
                        LlenarCboGrilla();
                        FormatoGrilla(DgvDatos);

                        GrillaLimpia2(DgvSalidas);
                        LlenarGrilla2();
                        FormatoGrilla2(DgvSalidas);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LogError.RegistroLog(ex.Message.ToString());
                }
            }
        }

        private void DgvDatos_KeyDown(object sender, KeyEventArgs e)
        {
            //suprimo el enter
            e.SuppressKeyPress = true;  
        }

        private void DgvSalidas_KeyDown(object sender, KeyEventArgs e)
        {
            //suprimo el enter
            e.SuppressKeyPress = true;  
        }

        private void DgvSalidas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string res = string.Empty;

            if (e.RowIndex != -1)
            {
                if (MessageBox.Show("Desea quitar Linea Seleccionada?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    _ENT_Lineas.IdLinea = Convert.ToInt32(DgvSalidas.Rows[e.RowIndex].Cells[0].Value);
                    _ENT_Tb_Tiendas.Alias_Tienda = DgvSalidas.Rows[e.RowIndex].Cells[1].Value.ToString();

                    res = _LGN_Tb_Lineas.Eliminar_Tienda_Salida(_ENT_Lineas, _ENT_Tb_Tiendas);

                    if (res == "1")
                    {
                        MessageBox.Show("Fueron modificados los registros de lineas, favor revisar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GrillaLimpia(DgvDatos);
                        LlenarGrilla();
                        LlenarCboGrilla();
                        FormatoGrilla(DgvDatos);
                        GrillaLimpia2(DgvSalidas);
                        LlenarGrilla2();
                        FormatoGrilla2(DgvSalidas);
                        return;
                    }
                    else
                    {
                        MessageBox.Show(res, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LogError.RegistroLog(res + "EliminarLineasTiendas");
                    }
                }
            }
        }

    }
}

