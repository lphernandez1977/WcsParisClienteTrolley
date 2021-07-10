namespace WcsParis
{
    partial class FrmRecuperarPass
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRecuperarPass));
            this.Label2 = new System.Windows.Forms.Label();
            this.TxtPassOld = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.TxtUsuario = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.Btn_Salir = new System.Windows.Forms.Button();
            this.Btn_Login = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtPassNew = new System.Windows.Forms.TextBox();
            this.ChkRecuperar = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.Navy;
            this.Label2.Location = new System.Drawing.Point(5, 150);
            this.Label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(155, 29);
            this.Label2.TabIndex = 44;
            this.Label2.Text = "Clave Actual";
            // 
            // TxtPassOld
            // 
            this.TxtPassOld.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPassOld.Location = new System.Drawing.Point(174, 148);
            this.TxtPassOld.Margin = new System.Windows.Forms.Padding(4);
            this.TxtPassOld.MaxLength = 20;
            this.TxtPassOld.Name = "TxtPassOld";
            this.TxtPassOld.PasswordChar = '*';
            this.TxtPassOld.Size = new System.Drawing.Size(328, 35);
            this.TxtPassOld.TabIndex = 1;
            this.TxtPassOld.Enter += new System.EventHandler(this.TxtPassOld_Enter);
            this.TxtPassOld.Leave += new System.EventHandler(this.TxtPassOld_Leave);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.ForeColor = System.Drawing.Color.Navy;
            this.Label3.Location = new System.Drawing.Point(5, 95);
            this.Label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(102, 29);
            this.Label3.TabIndex = 43;
            this.Label3.Text = "Usuario";
            // 
            // TxtUsuario
            // 
            this.TxtUsuario.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtUsuario.Location = new System.Drawing.Point(174, 92);
            this.TxtUsuario.Margin = new System.Windows.Forms.Padding(4);
            this.TxtUsuario.MaxLength = 20;
            this.TxtUsuario.Name = "TxtUsuario";
            this.TxtUsuario.Size = new System.Drawing.Size(328, 35);
            this.TxtUsuario.TabIndex = 0;
            this.TxtUsuario.Enter += new System.EventHandler(this.TxtUsuario_Enter);
            this.TxtUsuario.Leave += new System.EventHandler(this.TxtUsuario_Leave);
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.ForeColor = System.Drawing.Color.Navy;
            this.Label4.Location = new System.Drawing.Point(104, 27);
            this.Label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(284, 29);
            this.Label4.TabIndex = 42;
            this.Label4.Text = "CAMBIO CONTRASEÑA";
            // 
            // Btn_Salir
            // 
            this.Btn_Salir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Salir.Image = global::WcsParis.Properties.Resources.salir;
            this.Btn_Salir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_Salir.Location = new System.Drawing.Point(339, 300);
            this.Btn_Salir.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_Salir.Name = "Btn_Salir";
            this.Btn_Salir.Size = new System.Drawing.Size(160, 42);
            this.Btn_Salir.TabIndex = 46;
            this.Btn_Salir.Text = "Salir";
            this.Btn_Salir.UseVisualStyleBackColor = true;
            this.Btn_Salir.Click += new System.EventHandler(this.Btn_Salir_Click);
            // 
            // Btn_Login
            // 
            this.Btn_Login.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Login.Image = global::WcsParis.Properties.Resources.aceptar;
            this.Btn_Login.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_Login.Location = new System.Drawing.Point(172, 300);
            this.Btn_Login.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_Login.Name = "Btn_Login";
            this.Btn_Login.Size = new System.Drawing.Size(160, 42);
            this.Btn_Login.TabIndex = 45;
            this.Btn_Login.Text = "Aceptar";
            this.Btn_Login.UseVisualStyleBackColor = true;
            this.Btn_Login.Click += new System.EventHandler(this.Btn_Login_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(5, 200);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 29);
            this.label1.TabIndex = 48;
            this.label1.Text = "Clave Nueva";
            // 
            // TxtPassNew
            // 
            this.TxtPassNew.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPassNew.Location = new System.Drawing.Point(174, 198);
            this.TxtPassNew.Margin = new System.Windows.Forms.Padding(4);
            this.TxtPassNew.MaxLength = 20;
            this.TxtPassNew.Name = "TxtPassNew";
            this.TxtPassNew.PasswordChar = '*';
            this.TxtPassNew.Size = new System.Drawing.Size(328, 35);
            this.TxtPassNew.TabIndex = 2;
            this.TxtPassNew.Enter += new System.EventHandler(this.TxtPassNew_Enter);
            this.TxtPassNew.Leave += new System.EventHandler(this.TxtPassNew_Leave);
            // 
            // ChkRecuperar
            // 
            this.ChkRecuperar.AutoSize = true;
            this.ChkRecuperar.Location = new System.Drawing.Point(174, 254);
            this.ChkRecuperar.Name = "ChkRecuperar";
            this.ChkRecuperar.Size = new System.Drawing.Size(207, 21);
            this.ChkRecuperar.TabIndex = 50;
            this.ChkRecuperar.Text = "No Recuerdo Clave Anterior";
            this.ChkRecuperar.UseVisualStyleBackColor = true;
            // 
            // FrmRecuperarPass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 376);
            this.Controls.Add(this.ChkRecuperar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtPassNew);
            this.Controls.Add(this.Btn_Salir);
            this.Controls.Add(this.Btn_Login);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.TxtPassOld);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.TxtUsuario);
            this.Controls.Add(this.Label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmRecuperarPass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "e-MAC Ingeniería Eléctrica y Mantenimiento Industrial";
            this.Load += new System.EventHandler(this.FrmRecuperarPass_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox TxtPassOld;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox TxtUsuario;
        internal System.Windows.Forms.Label Label4;
        private System.Windows.Forms.Button Btn_Salir;
        private System.Windows.Forms.Button Btn_Login;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox TxtPassNew;
        private System.Windows.Forms.CheckBox ChkRecuperar;
    }
}