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
    public partial class FrmRecuperarPass : Form
    {
        cMD5 oEncriptar = new cMD5();
        cTb_Usuarios _cTb_Usuarios = new cTb_Usuarios();
        cTb_Usuarios oUser = new cTb_Usuarios();
        public cENT_Usuarios oSistemas = new cENT_Usuarios();
        LGN_Tb_Usuarios _LGN_Tb_Usuarios = new LGN_Tb_Usuarios();
        ACD_Tb_Usuarios _ACD_Tb_Usuarios = new ACD_Tb_Usuarios();

        //utilizamos la clase para saltar al siguiente control
        CLS_Utilidades.CLS_SeteaFormatoGrilla _seteaformato = new CLS_Utilidades.CLS_SeteaFormatoGrilla();
        CLS_Utilidades.CLS_Ilumina_Texto _iluminaTexto = new CLS_Utilidades.CLS_Ilumina_Texto();

        public FrmRecuperarPass()
        {
            InitializeComponent();
        }

        private void Btn_Login_Click(object sender, EventArgs e)
        {
            string op = string.Empty;

            if (ChkRecuperar.Checked)
            {
                if (string.IsNullOrEmpty(TxtUsuario.Text))
                {
                    MessageBox.Show("Se debe llenar todos los campos solicitados", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TxtUsuario.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(TxtPassNew.Text))
                {
                    MessageBox.Show("Se debe llenar todos los campos solicitados", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TxtPassNew.Focus();
                    return;
                }

                oUser.Nom_Usuario = TxtUsuario.Text.Trim();
                oUser.Contrasenia = cMD5.Encriptar("sinclave");
                oUser.NuevaContrasenia = cMD5.Encriptar(TxtPassNew.Text.Trim());
                oUser.Mensaje = "formateo";

                op = _LGN_Tb_Usuarios.Actualiza_Passwword(oUser);

                if (op == "1") 
                {
                    MessageBox.Show("Cambio de contraseña se realizo en forma correcta.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TxtUsuario.Text = string.Empty;
                    TxtPassNew.Text = string.Empty;
                    TxtPassOld.Text = string.Empty;
                    TxtUsuario.Focus();
                    return;                
                }
                else
                {
                    MessageBox.Show(op, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TxtUsuario.Focus();
                    return;      
                }
            }

            else
            {
                if (string.IsNullOrEmpty(TxtUsuario.Text))
                {
                    MessageBox.Show("Se debe llenar todos los campos solicitados", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TxtUsuario.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(TxtPassNew.Text))
                {
                    MessageBox.Show("Se debe llenar todos los campos solicitados", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TxtPassNew.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(TxtPassOld.Text))
                {
                    MessageBox.Show("Se debe llenar todos los campos solicitados", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TxtPassOld.Focus();
                    return;
                }

                oUser.Nom_Usuario = TxtUsuario.Text.Trim();
                oUser.Contrasenia = cMD5.Encriptar(TxtPassOld.Text.Trim());
                oUser.NuevaContrasenia = cMD5.Encriptar(TxtPassNew.Text.Trim());
                oUser.Mensaje = "cambio";

                op = _LGN_Tb_Usuarios.Actualiza_Passwword(oUser);

                if (op == "1")
                {
                    MessageBox.Show("Cambio de contraseña se realizo en forma correcta.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TxtUsuario.Text = string.Empty;
                    TxtPassNew.Text = string.Empty;
                    TxtPassOld.Text = string.Empty;
                    TxtUsuario.Focus();
                    return;
                }
                else
                {
                    MessageBox.Show(op, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TxtUsuario.Focus();
                    return;
                }
            }






        }

        private void TxtUsuario_Enter(object sender, EventArgs e)
        {
            _iluminaTexto.Activa_Texto(TxtUsuario);
        }

        private void TxtPassOld_Enter(object sender, EventArgs e)
        {
            _iluminaTexto.Activa_Texto(TxtPassOld);
        }

        private void TxtPassNew_Enter(object sender, EventArgs e)
        {
            _iluminaTexto.Activa_Texto(TxtPassNew);
        }

        private void TxtUsuario_Leave(object sender, EventArgs e)
        {
            _iluminaTexto.Desactiva_Texto(TxtUsuario);
        }

        private void TxtPassOld_Leave(object sender, EventArgs e)
        {
            _iluminaTexto.Desactiva_Texto(TxtPassOld);
        }

        private void TxtPassNew_Leave(object sender, EventArgs e)
        {
            _iluminaTexto.Desactiva_Texto(TxtPassNew);
        }

        private void Btn_Salir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea salir?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void FrmRecuperarPass_Load(object sender, EventArgs e)
        {

        }
    
    }
}
