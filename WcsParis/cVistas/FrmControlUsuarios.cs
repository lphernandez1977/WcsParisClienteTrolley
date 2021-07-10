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
    public partial class FrmControlUsuarios : Form
    {
        cMD5 oEncriptar = new cMD5();
        cTb_Usuarios oUsuarios = new cTb_Usuarios();
        LGN_Tb_Usuarios oLGN_Tb_Usuarios = new LGN_Tb_Usuarios();
        LGN_Tb_Nivel oLGN_Tb_Nivel = new LGN_Tb_Nivel();

        bool flag = false;

        //utilizamos la clase para saltar al siguiente control
        CLS_Utilidades.CLS_SeteaFormatoGrilla _seteaformato = new CLS_Utilidades.CLS_SeteaFormatoGrilla();
        CLS_Utilidades.CLS_Ilumina_Texto _iluminaTexto = new CLS_Utilidades.CLS_Ilumina_Texto();


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

            _seteaformato.CreaGrillaLimpia(dtg, 0, "Id_Usuario", true);
            _seteaformato.CreaGrillaLimpia(dtg, 1, "Nom_Usuario", true);
            _seteaformato.CreaGrillaLimpia(dtg, 2, "Nom_Nivel", true);
            _seteaformato.CreaGrillaLimpia(dtg, 3, "Estado_Usuario", true);
            _seteaformato.CreaGrillaLimpia(dtg, 4, "Fecha_Crea", true);
            _seteaformato.CreaGrillaLimpia(dtg, 5, "Contraseña", true);
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

            _seteaformato.SeteaFormatoGrilla(dtg, 0, "Id_Usuario", 80, false, Alineacion.Derecha.ToString(), true);
            _seteaformato.SeteaFormatoGrilla(dtg, 1, "Usuario", 142, true, Alineacion.Izquierda.ToString(), true);
            _seteaformato.SeteaFormatoGrilla(dtg, 2, "Nivel", 142, true, Alineacion.Izquierda.ToString(), true);
            _seteaformato.SeteaFormatoGrilla(dtg, 3, "Estado", 142, true, Alineacion.Izquierda.ToString(), true);
            _seteaformato.SeteaFormatoGrilla(dtg, 4, "Fecha_Crea", 100, false, Alineacion.Izquierda.ToString(), true);
            _seteaformato.SeteaFormatoGrilla(dtg, 5, "Contraseña", 100, false, Alineacion.Izquierda.ToString(), true);
  
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
            DgvDatos.MultiSelect = false;

        }
        #endregion

        public FrmControlUsuarios()
        {
            InitializeComponent();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            string res = string.Empty;
            oUsuarios.Nom_Usuario = TxtUsuario.Text;
            oUsuarios.Contrasenia = cMD5.Encriptar(TxtPass.Text.Trim());

            if (CboNivel.SelectedIndex == 0) { MessageBox.Show("Debe seleccionar un nivel valido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (CboEstado.SelectedIndex == 0) { MessageBox.Show("Debe seleccionar un estado valido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            //valida estado
            if (CboEstado.SelectedIndex == 1) { oUsuarios.Estado_Usuario = true; }
            if (CboEstado.SelectedIndex == 2) { oUsuarios.Estado_Usuario = false; }

            oUsuarios.Nivel = CboNivel.SelectedIndex;

            if (string.IsNullOrEmpty(oUsuarios.Nom_Usuario) || (string.IsNullOrEmpty(oUsuarios.Contrasenia)))
            {
                MessageBox.Show("Se debe llenar todos los campos solicitados", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TxtUsuario.Focus();
                return;
            }
            else
            {

                if (flag)
                {
                    //editar usuarios
                    res = oLGN_Tb_Usuarios.Editar_Tb_Usuarios(oUsuarios);

                    if (res == "1")
                    {
                        MessageBox.Show("Usuario editado en forma correcta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BorrarCajas();
                        LlenarGrilla();
                        FormatoGrilla(DgvDatos);
                        LenarCboNivel();
                        LlenarCboEstado();
                        TxtUsuario.Focus();
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
                    res = oLGN_Tb_Usuarios.Inserta_Tb_Usuarios(oUsuarios);

                    if (res == "1")
                    {
                        MessageBox.Show("Usuario creado en forma correcta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BorrarCajas();
                        LlenarGrilla();
                        FormatoGrilla(DgvDatos);
                        LenarCboNivel();
                        LlenarCboEstado();
                        TxtUsuario.Focus();
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
            TxtUsuario.Text = string.Empty;
            TxtPass.Text = string.Empty;                    
        }

        private void LenarCboNivel() 
        {
            List<cTb_Nivel> lista = new List<cTb_Nivel>();

            lista.Add(new cTb_Nivel("Seleccionar Nivel", 0));
            lista.Add(new cTb_Nivel("Administrador", 1));
            lista.Add(new cTb_Nivel("Invitado", 2));


            //Vaciar comboBox
            this.CboNivel.DataSource = null;

            //Asignar la propiedad DataSource
            this.CboNivel.DataSource = lista;

            //Indicar qué propiedad se verá en la lista
            this.CboNivel.DisplayMember = "Name";

            //Indicar qué valor tendrá cada ítem
            this.CboNivel.ValueMember = "Value";       
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

            DataSet dsdatos = new DataSet();
            //lleno dataset
            dsdatos = oLGN_Tb_Usuarios.Listado_Usuarios();

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
                    //cierra formulario de Carga
                    //FrmEspere.CerrarVentanaCarga(FrmEspere);  

                }
            }
            catch (Exception ex)
            {
                //FrmEspere.CerrarVentanaCarga(FrmEspere);
            }
        
        }

        private void FrmControlUsuarios_Load(object sender, EventArgs e)
        {
            LenarCboNivel();
            CboNivel.SelectedIndex = 0;
            LlenarCboEstado();
            CboEstado.SelectedIndex = 0;

            GrillaLimpia(DgvDatos);
            LlenarGrilla();
            FormatoGrilla(DgvDatos);
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea salir?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void TxtUsuario_Enter(object sender, EventArgs e)
        {
            _iluminaTexto.Activa_Texto(TxtUsuario);
        }

        private void TxtUsuario_Leave(object sender, EventArgs e)
        {
            _iluminaTexto.Desactiva_Texto(TxtUsuario);
        }

        private void TxtPass_Enter(object sender, EventArgs e)
        {
            _iluminaTexto.Activa_Texto(TxtPass);
        }

        private void TxtPass_Leave(object sender, EventArgs e)
        {
            _iluminaTexto.Desactiva_Texto(TxtPass);
        }

        private void CboNivel_Enter(object sender, EventArgs e)
        {
            _iluminaTexto.Activa_Texto(CboNivel);
        }

        private void CboNivel_Leave(object sender, EventArgs e)
        {
            _iluminaTexto.Desactiva_Texto(CboNivel);
        }

        private void DgvDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                TxtUsuario.Text = Convert.ToString(DgvDatos.Rows[e.RowIndex].Cells[1].Value.ToString());

                if (Convert.ToString(DgvDatos.Rows[e.RowIndex].Cells[2].Value.ToString()) == "Administrador")
                {
                    CboNivel.SelectedValue = 1;
                }
                else
                {
                    CboNivel.SelectedValue = 2;
                }

                if (Convert.ToString(DgvDatos.Rows[e.RowIndex].Cells[3].Value.ToString()) == "Activo")
                {
                    CboEstado.SelectedValue = 1;
                }
                else
                {
                    CboEstado.SelectedValue = 2;
                }

                TxtPass.Text = Convert.ToString(DgvDatos.Rows[e.RowIndex].Cells[5].Value.ToString());
                
                //quito registro grilla
                DgvDatos.Rows.RemoveAt(e.RowIndex);
                flag = true;
                BtnGuardar.Text = "Editar";
            }
        }

        private void DgvDatos_KeyDown(object sender, KeyEventArgs e)
        {
            //suprimo el enter
            e.SuppressKeyPress = true;  
        }

    }
}